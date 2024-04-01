using EscrowPro.Core.Dtos;
using EscrowPro.Service.Services;
using EscrowPro.Infrastructure.Data;
using Moq;

namespace BuyerService.Tests
{
    [TestFixture]
    public class CreateBuyerAsyncTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task CreateBuyer_PassingNullInput_ReturnsNull()
        {
            BuyerCreateDto buyerCreateDto = null;
            var mockContext = new Mock<EscrowProContext>();
            var buyerService = new BuyerServices(mockContext.Object);
            var result = await buyerService.CreateBuyerAsync(buyerCreateDto);
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateBuyer_PassingValues_ReturnCreatedNewBuyerValues()
        {
            var buyerCreateDto = new BuyerCreateDto
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = 0321-7553432,
                CNIC = 12345-6789012-3
            };
            var mockContext = new Mock<EscrowProContext>();
            var buyerService = new BuyerServices(mockContext.Object);
            var result = await buyerService.CreateBuyerAsync(buyerCreateDto);
            Assert.That(result.Name, Is.EqualTo(buyerCreateDto.Name));
            Assert.That(result.Email, Is.EqualTo(buyerCreateDto.Email));
            Assert.That(result.ConfirmPassword, Is.EqualTo(buyerCreateDto.ConfirmPassword));
            Assert.That(result.Phone, Is.EqualTo(buyerCreateDto.Phone));
            Assert.That(result.CNIC, Is.EqualTo(buyerCreateDto.CNIC));
        }

    }
}
