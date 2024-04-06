using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/Buyer")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerServices _buyerServices;

        public BuyerController(IBuyerServices buyerServices)
        {
            _buyerServices=buyerServices;
        }

        [HttpPost]
        public async Task<ActionResult<ReadBuyerDto>> CreateBuyerAsync(CreateBuyerDto createBuyerDto)
        {
            var newBuyer = new CreateBuyerDto
            {
                Name = createBuyerDto.Name,
                Email = createBuyerDto.Email,
                Password = createBuyerDto.Password,
                ConfirmPassword = createBuyerDto.ConfirmPassword,
                CNIC = createBuyerDto.CNIC,
                Phone = createBuyerDto.Phone,
                RegistrationDate = DateTime.Now,
            };

            var readNewBuyer = new ReadBuyerDto
            {
                Name=newBuyer.Name,
                Email=newBuyer.Email,
                CNIC=newBuyer.CNIC,
                Phone = newBuyer.Phone
            };
            await _buyerServices.CreateBuyerAsync(newBuyer);
            return Ok(readNewBuyer);
        }
    }
}
