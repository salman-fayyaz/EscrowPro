using EscrowPro.Core.Dtos;
using EscrowPro.Service.Services;
using EscrowPro.Infrastructure.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;
using EscrowPro.Core.Models;
using EscrowPro.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ControllersTest
{
    [TestFixture]
    public class BuyerControllerTests
    {

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public async Task CreateBuyerAsync_PassingValues_ReturnsOkResult()
        {
            var mockBuyerServices = new Mock<IBuyerServices>();
            var controller = new BuyerController(mockBuyerServices.Object);
            var createBuyerDto = new CreateBuyerDto
            {
                Name = "salmanFayyaz",
                Email = "sfayyaz4c@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                CNIC = "12345-1234567-2",
                Phone = "0355-3234222"
            };

            var result = await controller.CreateBuyerAsync(createBuyerDto);
            Assert.NotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
