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

        private readonly IMapper _mapper;

        public BuyerController(IBuyerServices buyerServices, IMapper mapper)
        {
            _buyerServices=buyerServices;
            _mapper=mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReadBuyerDto>> CreateBuyer(CreateBuyerDto createBuyerDto)
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
            await _buyerServices.CreateBuyerAsync(newBuyer);
            return Ok(newBuyer);
        }

    }
}
