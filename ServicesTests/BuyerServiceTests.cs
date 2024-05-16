using EscrowPro.Core.Dtos;
using EscrowPro.Service.Services;
using EscrowPro.Infrastructure.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using AutoMapper;
using EscrowPro.Infrastructure.Repositories;
using EscrowPro.Core.Profiles;

namespace ServicesTests
{
    [TestFixture]
    public class BuyerServiceTests
    {
        private  IBuyerService _buyerServices;
        private Mock<IBuyerRepository> _mockBuyerRepository;
        private  IMapper _mapper;


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
            var mock = new Mock<BuyerService>();
            _mockBuyerRepository = new Mock<IBuyerRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new BuyerProfile()));
            _mapper = mapperConfig.CreateMapper();
            var mockMapper = new Mock<IMapper>();
            _buyerServices = new BuyerService(_mockBuyerRepository.Object, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            //_context.Dispose();
        }

        [Test]
        public async Task CreateBuyerAsync_PassingNullInput_ReturnsNull()
        {
            
            CreateBuyerDto createBuyerDto = null;
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _buyerServices.CreateBuyerAsync(createBuyerDto);
            });
        }

        [Test]
        public async Task CreateBuyerAsync_PassingValues_ReturnCreatedNewBuyerValues()
        {
            var createBuyerDto = new CreateBuyerDto
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _buyerServices.CreateBuyerAsync(createBuyerDto);
        }

        [Test]
        public async Task deletebuyerasync_whenpassingnotfound_returnsnull()
        {
            var buyer = new Buyer()
            {
                Id = 1,
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            _mockBuyerRepository.Setup(repo => repo.DeleteBuyerAsync(It.IsAny<int>())).ReturnsAsync((Buyer)null);
            var result = await _buyerServices.DeleteBuyerAsync(1);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteBuyerAsync_WhenPassingIdFound_ReturnsDeletedBuyer()
        {
            var buyerModel = new Buyer
            {
                Id = 1,
                Name = "Salmanss",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            _mockBuyerRepository.Setup(repo => repo.DeleteBuyerAsync(It.IsAny<int>()))
                                .ReturnsAsync(buyerModel);
            var result = await _buyerServices.DeleteBuyerAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(buyerModel.Name, result.Name);
            Assert.AreEqual(buyerModel.Email, result.Email);
            Assert.AreEqual(buyerModel.CNIC, result.CNIC);
            Assert.AreEqual(buyerModel.Phone, result.Phone);
        }

        [Test]
        public async Task GetALlBuyers_WhenCalled_ReturnAllBuyers()
        {
            var buyerDto = new CreateBuyerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var buyer = new Buyer
            {
                Name=buyerDto.Name,
                Email=buyerDto.Email,
                Password=buyerDto.Password,
                ConfirmPassword=buyerDto.ConfirmPassword,
                Phone=buyerDto.Phone,
                CNIC=buyerDto.CNIC
            };
            _mockBuyerRepository.Setup(repo => repo.GetAllBuyersAsync()).ReturnsAsync(new List<Buyer> {buyer});
            await _buyerServices.CreateBuyerAsync(buyerDto);
            var buyersReturnedList = await _buyerServices.GetAllBuyersAsync();
            Assert.IsNotNull(buyersReturnedList);
            Assert.That(buyersReturnedList.Any(b => b.Name == "Salman"));
            Assert.That(buyersReturnedList.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(buyersReturnedList.Any(b => b.CNIC == "12345-6789012-3"));
            Assert.That(buyersReturnedList.Any(b => b.Phone == "0321-7553432"));
        }

        [Test]
        public async Task GetbuyerById_WhenPassingIdNotFound_ReturnsNull()
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
            var result = await _buyerServices.GetBuyerByIdAsync(2);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetbuyerById_WhenPassingIdFound_ReturnsBuyer()
        {
            var buyerDto = new CreateBuyerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var buyer = new Buyer
            {
                Name = buyerDto.Name,
                Email = buyerDto.Email,
                Password = buyerDto.Password,
                ConfirmPassword = buyerDto.ConfirmPassword,
                Phone = buyerDto.Phone,
                CNIC = buyerDto.CNIC
            };
            _mockBuyerRepository.Setup(repo => repo.GetBuyerByIdAsync(It.IsAny<int>())).ReturnsAsync(buyer);
            await _buyerServices.CreateBuyerAsync(buyerDto);
            var foundedBuyer = await _buyerServices.GetBuyerByIdAsync(1);
            Assert.That(foundedBuyer, Is.Not.Null);
            Assert.That(foundedBuyer.Name, Is.EqualTo("Salman"));
            Assert.That(foundedBuyer.Email, Is.EqualTo("sfayyaz7c@gmail.com"));
            Assert.That(foundedBuyer.CNIC, Is.EqualTo("12345-6789012-3"));
            Assert.That(foundedBuyer.Phone, Is.EqualTo("0321-7553432"));
        }

        //[Test]
        //public async Task UpdateBuyer_whenPassingIdFound_ReturnsUpdatedBuyer()
        //{
        //    var buyer = new CreateBuyerDto()
        //    {
        //        //here selfgenerated Id=1
        //        Name = "Salman",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    await _buyerServices.CreateBuyerAsync(buyer);
        //    var updateBuyer = new UpdateBuyerDto
        //    {
        //        Name = "xyz",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    var result = await _buyerServices.UpdateBuyerAsync(1, updateBuyer);
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.Any(b => b.Name == "xyz"));
        //    Assert.That(result.Any(b => b.Email == "sfayyaz7c@gmail.com"));
        //    Assert.That(result.Any(b => b.Password == "password123"));
        //    Assert.That(result.Any(b => b.ConfirmPassword == "password123"));
        //    Assert.That(result.Any(b => b.Phone == "0321-7553432"));
        //    Assert.That(result.Any(b => b.CNIC == "12345-6789012-3"));
        //}

    }
}
