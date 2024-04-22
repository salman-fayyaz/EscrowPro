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



    }
}
