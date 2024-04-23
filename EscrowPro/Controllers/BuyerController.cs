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
        private readonly IBuyerService _buyerServices;

        public BuyerController(IBuyerService buyerServices)
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

            var readNewBuyerDto = new ReadBuyerDto
            {
                Name=newBuyer.Name,
                Email=newBuyer.Email,
                CNIC=newBuyer.CNIC,
                Phone = newBuyer.Phone
            };
            await _buyerServices.CreateBuyerAsync(newBuyer);
            return Ok(readNewBuyerDto);
        }

        [HttpGet]
        public async Task<ActionResult<ReadBuyerDto>> GetAllBuyersAsync()
        {
            var buyers=await _buyerServices.GetAllBuyersAsync();
            return Ok(buyers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadBuyerDto>> GetBuyerByIdAsync(int id)
        {
            var buyer = await _buyerServices.GetBuyerByIdAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer);
        }
    }
}
