using EscrowPro.Core.Dtos;
using EscrowPro.Service.Services;
using EscrowPro.Infrastructure.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;
using EscrowPro.Core.Models;

namespace ServicesTests
{
    [TestFixture]
    public class BuyerServiceTests
    {
        private IBuyerService _buyerServices;
        private EscrowProContext _context;


        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<EscrowProContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .UseInternalServiceProvider(serviceProvider)
            .Options;

            _context = new EscrowProContext(options);
            _buyerServices = new EscrowPro.Service.Services.BuyerService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateBuyerAsync_PassingNullInput_ReturnsNull()
        {
            CreateBuyerDto buyerCreateDto = null;
            var mockContext = new Mock<EscrowProContext>();
            var buyerService = new BuyerService(mockContext.Object);
            var result = await buyerService.CreateBuyerAsync(buyerCreateDto);
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateBuyerAsync_PassingValues_ReturnCreatedNewBuyerValues()
        {
            var buyerCreateDto = new CreateBuyerDto
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var result = await _buyerServices.CreateBuyerAsync(buyerCreateDto);
            Assert.That(result.Name, Is.EqualTo(buyerCreateDto.Name));
            Assert.That(result.Email, Is.EqualTo(buyerCreateDto.Email));
            Assert.That(result.ConfirmPassword, Is.EqualTo(buyerCreateDto.ConfirmPassword));
            Assert.That(result.Phone, Is.EqualTo(buyerCreateDto.Phone));
            Assert.That(result.CNIC, Is.EqualTo(buyerCreateDto.CNIC));
        }

        [Test]
        public async Task DeleteBuyerAsync_WhenPassingNotFound_ReturnsNull()
        {
            var buyer = new Buyer()
            {
                Id = 2,
            };
            var result = await _buyerServices.DeleteBuyerAsync(1);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteBuyerAsync_WhenPassingIdFound_ReturnsPassedId()
        {
            var buyer = new CreateBuyerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(buyer);
            var result = await _buyerServices.DeleteBuyerAsync(1);
            Assert.IsNotNull(result);
            Assert.That(buyer.Name, Is.EqualTo(result[0].Name));
            Assert.That(buyer.Email, Is.EqualTo(result[0].Email));
            Assert.That(buyer.CNIC, Is.EqualTo(result[0].CNIC));
            Assert.That(buyer.Phone, Is.EqualTo(result[0].Phone));
        }

        [Test]
        public async Task GetALlBuyers_WhenCalled_ReturnAllBuyers()
        {
            var buyer = new CreateBuyerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(buyer);
            var buyersList=await _buyerServices.GetAllBuyersAsync();
            Assert.IsNotNull(buyersList);
            Assert.That(buyersList.Any(b => b.Name == "Salman"));
            Assert.That(buyersList.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(buyersList.Any(b => b.CNIC == "12345-6789012-3"));
            Assert.That(buyersList.Any(b => b.Phone == "0321-7553432"));
        }

        [Test]
        public async Task GetbuyerById_WhenPassingIdNotFound_ReturnsNull()
        {
            var buyer = new CreateBuyerDto()
            {
                //here it is automatically generate id=1, but i ask for 2 which is not created so
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(buyer);
            var result = await _buyerServices.GetBuyerByIdAsync(2);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetbuyerById_WhenPassingIdFound_ReturnsBuyer()
        {
            var buyer = new CreateBuyerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(buyer);
            var foundedBuyer = await _buyerServices.GetBuyerByIdAsync(1);
            Assert.That(foundedBuyer, Is.Not.Null);
            Assert.That(foundedBuyer.Any(b => b.Id == 1));
            Assert.That(foundedBuyer.Any(b => b.Name == "Salman"));
            Assert.That(foundedBuyer.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(foundedBuyer.Any(b => b.Phone == "0321-7553432"));
            Assert.That(foundedBuyer.Any(b => b.CNIC == "12345-6789012-3"));
        }

        [Test]
        public async Task UpdateBuyer_whenPassingIdNotFound_ReturnsNull()
        {
            var buyer = new CreateBuyerDto()
            {
                //here selfgenerated Id=1
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(buyer);
            var updateBuyer = new UpdateBuyerDto
            {
                Name="xyz",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var result = await _buyerServices.UpdateBuyerAsync(1,updateBuyer);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Any(b => b.Name == "xyz"));
            Assert.That(result.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(result.Any(b => b.Password == "password123"));
            Assert.That(result.Any(b => b.ConfirmPassword == "password123"));
            Assert.That(result.Any(b => b.Phone == "0321-7553432"));
            Assert.That(result.Any(b => b.CNIC == "12345-6789012-3"));
        }

    }
}
