using EscrowPro.Core.Dtos;
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
            _sellerServices = new EscrowPro.Service.Services.SellerService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateSellerAsync_PassingNull_ReturnsNull()
        {
            CreateSellerDto createSellerDto = null;
            var mockContext = new Mock<EscrowProContext>();
            var sellerServices = new SellerService(mockContext.Object);
            var result= await sellerServices.CreateSellerAsync(createSellerDto);
            Assert.IsNull(result);
        }

        [Test]
        public async Task createSellerAsync_PassingValues_ReturnsCreatedSeller()
        {
            var newSeller = new CreateSellerDto
            {
                Name="Faizan",
                Email="ffayyaz7c@gmail.com",
                Password="pass123",
                ConfirmPassword="pass123",
                CNIC="12345-4324473-9",
                Phone="0344-6392526",
            };
            var result=await _sellerServices.CreateSellerAsync(newSeller);
            Assert.That(result.Name, Is.EqualTo(newSeller.Name));
            Assert.That(result.Email, Is.EqualTo(newSeller.Email));
            Assert.That(result.Password, Is.EqualTo(newSeller.Password));
            Assert.That(result.ConfirmPassword, Is.EqualTo(newSeller.ConfirmPassword));
            Assert.That(result.CNIC, Is.EqualTo(newSeller.CNIC));
            Assert.That(result.Phone, Is.EqualTo(newSeller.Phone));
        }

        [Test]
        public async Task GetAllSellersAsync_WhenCalled_ReturnsAllSellers()
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
            var sellersList = await _sellerServices.GetAllSellersAsync();
            Assert.IsNotNull(sellersList);
            Assert.That(sellersList.Any(b => b.Name == "Salman"));
            Assert.That(sellersList.Any(b => b.Email == "sfayyaz7c@gmail.com"));
            Assert.That(sellersList.Any(b => b.CNIC == "12345-6789012-3"));
            Assert.That(sellersList.Any(b => b.Phone == "0321-7553432"));
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
            var seller = new CreateSellerDto()
            {
                Name = "faizan",
                Email = "ffayyaz7c@gmail.com",
                Password = "pass123",
                ConfirmPassword = "pass123",
                Phone = "0321-7553632",
                CNIC = "12345-6789032-9"
            };
            await _sellerServices.CreateSellerAsync(seller);
            var foundSeller = await _sellerServices.GetSellerByIdAsync(1);
            Assert.That(foundSeller, Is.Not.Null);
            Assert.That(foundSeller.Any(b => b.Id == 1));
            Assert.That(foundSeller.Any(b => b.Name == "faizan"));
            Assert.That(foundSeller.Any(b => b.Email == "ffayyaz7c@gmail.com"));
            Assert.That(foundSeller.Any(b => b.Phone == "0321-7553632"));
            Assert.That(foundSeller.Any(b => b.CNIC == "12345-6789032-9"));
        }


    }
}
