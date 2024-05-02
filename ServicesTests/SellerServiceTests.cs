using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Profiles;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using EscrowPro.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace ServicesTests
{
    public class SellerServiceTests
    {
        private ISellerService _sellerServices;
        private Mock<ISellerRepository> _mockSellerRepository;
        private IMapper _mapper;

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
            var mock = new Mock<SellerService>();
            _mockSellerRepository = new Mock<ISellerRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new SellerProfile()));
            _mapper = mapperConfig.CreateMapper();
            var mockMapper = new Mock<IMapper>();
            _sellerServices = new SellerService(_mockSellerRepository.Object, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public async Task CreateSellerAsync_PassingNull_ReturnsNull()
        {
            CreateSellerDto createsellerDto = null;
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _sellerServices.CreateSellerAsync(createsellerDto);
            });
        }

        [Test]
        public async Task createSellerAsync_PassingValues_ReturnsCreatedSeller()
        {
            var createSellerDto = new CreateSellerDto
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _sellerServices.CreateSellerAsync(createSellerDto);
        }

        [Test]
        public async Task GetAllSellersAsync_WhenCalled_ReturnsAllSellers()
        {
            var sellerDto = new CreateSellerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var seller = new Seller
            {
                Name = sellerDto.Name,
                Email = sellerDto.Email,
                Password = sellerDto.Password,
                ConfirmPassword = sellerDto.ConfirmPassword,
                Phone = sellerDto.Phone,
                CNIC =  sellerDto.CNIC
            };
            _mockSellerRepository.Setup(repo => repo.GetAllSellerAsync()).ReturnsAsync(new List<Seller> { seller });
            await _sellerServices.CreateSellerAsync(sellerDto);
            var sellersReturnedList = await _sellerServices.GetAllSellersAsync();
            Assert.IsNotNull(sellersReturnedList);
            Assert.That(sellersReturnedList.Any(b => b.Name == "Salman"));
            Assert.That(sellersReturnedList.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(sellersReturnedList.Any(b => b.CNIC == "12345-6789012-3"));
            Assert.That(sellersReturnedList.Any(b => b.Phone == "0321-7553432"));
        }

        [Test]
        public async Task GetSellerByIdAsync_WhenPassingIdNotFound_ReturnsNull()
        {
            var seller = new CreateSellerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            await _sellerServices.CreateSellerAsync(seller);
            var result = await _sellerServices.GetSellerByIdAsync(2);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetSellerByIdAsync_WhenPassingIdFound_ReturnsSeller()
        {
            var sellerDto = new CreateSellerDto()
            {
                Name = "Salman",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            var seller = new Seller
            {
                Name = sellerDto.Name,
                Email = sellerDto.Email,
                Password = sellerDto.Password,
                ConfirmPassword = sellerDto.ConfirmPassword,
                Phone = sellerDto.Phone,
                CNIC =  sellerDto.CNIC
            };
            _mockSellerRepository.Setup(repo => repo.GetSellerByIdAsync(It.IsAny<int>())).ReturnsAsync(seller);
            await _sellerServices.CreateSellerAsync(sellerDto);
            var foundedSeller = await _sellerServices.GetSellerByIdAsync(1);
            Assert.That(foundedSeller, Is.Not.Null);
            Assert.That(foundedSeller.Name, Is.EqualTo("Salman"));
            Assert.That(foundedSeller.Email, Is.EqualTo("sfayyaz7c@gmail.com"));
            Assert.That(foundedSeller.CNIC, Is.EqualTo("12345-6789012-3"));
            Assert.That(foundedSeller.Phone, Is.EqualTo("0321-7553432"));
        }

        [Test]
        public async Task DeleteSellerAsync_WhenPassingNotFound_ReturnsNull()
        {
            var seller = new Seller()
            {
                Id = 2,
            };
            var result = await _sellerServices.DeleteSellerAsync(1);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteSellerAsync_WhenPassingIdFound_ReturnsDeletedSeller()
        {
            var sellerModel = new Seller
            {
                Id = 1,
                Name = "Salmanss",
                Email = "sfayyaz7c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Phone = "0321-7553432",
                CNIC = "12345-6789012-3"
            };
            _mockSellerRepository.Setup(repo => repo.DeleteSellerAsync(It.IsAny<int>()))
                                .ReturnsAsync(sellerModel);
            var result = await _sellerServices.DeleteSellerAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(sellerModel.Name, result.Name);
            Assert.AreEqual(sellerModel.Email, result.Email);
            Assert.AreEqual(sellerModel.CNIC, result.CNIC);
            Assert.AreEqual(sellerModel.Phone, result.Phone);
        }

        //[Test]
        //public async Task UpdateSeller_whenPassingIdFound_ReturnsUpdatedSeller()
        //{
        //    var seller = new CreateSellerDto()
        //    {
        //        Name = "Salman",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    await _sellerServices.CreateSellerAsync(seller);
        //    var updateSeller = new UpdateSellerDto
        //    {
        //        Name = "xyz",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    var result = await _sellerServices.UpdateSellerAsync(1, updateSeller);
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.Any(b => b.Name == "xyz"));
        //    Assert.That(result.Any(b => b.Email == "sfayyaz7c@gmail.com"));
        //    Assert.That(result.Any(b => b.Password == "password123"));
        //    Assert.That(result.Any(b => b.ConfirmPassword == "password123"));
        //    Assert.That(result.Any(b => b.Phone == "0321-7553432"));
        //    Assert.That(result.Any(b => b.CNIC == "12345-6789012-3"));
        //}

        //[Test]
        //public async Task SellProductAsync_IfSellerIdNotFound_ThrowsInvalidOperationsExceptions()
        //{
        //    var seller = new CreateSellerDto
        //    {
        //        //here id=1 Self Generated ID in memory database due to auto generated validation 
        //        Name = "xyz",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    var product = new CreateProductDto
        //    {
        //        Name="Laptop",
        //        Price=25000,
        //        Description="qwertti good bad both",
        //        Quantity=1,
        //    };
        //    await _sellerServices.CreateSellerAsync(seller);
        //    //here i will pass 2 for checking,  as i know 1 is availbe and 2 is  not
        //    Assert.ThrowsAsync<InvalidOperationException>(() => _sellerServices.SellProductAsync(2,product));
        //}

        //[Test]
        //public async Task SellProductAsync_IfSellerFound_ProductIsAdded()
        //{
        //    var seller = new CreateSellerDto
        //    {
        //        Name = "xyz",
        //        Email = "sfayyaz7c@gmail.com",
        //        Password = "password123",
        //        ConfirmPassword = "password123",
        //        Phone = "0321-7553432",
        //        CNIC = "12345-6789012-3"
        //    };
        //    var product = new CreateProductDto
        //    {
        //        Name = "Laptop",
        //        Price = 25000,
        //        Description = "qwertti good bad both",
        //        Quantity = 1,
        //    };
        //    await _sellerServices.CreateSellerAsync(seller);
        //    Assert.DoesNotThrowAsync(()=> _sellerServices.SellProductAsync(1, product));

        //}
        
    }
}
