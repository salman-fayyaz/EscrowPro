using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        public async Task<ActionResult> CreateBuyerAsync([FromBody]CreateBuyerDto createBuyerDto)
        {
            await _buyerServices.CreateBuyerAsync(createBuyerDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReadBuyerDto>> GetAllBuyersAsync()
        {
            var buyers = await _buyerServices.GetAllBuyersAsync();
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadBuyerDto>> DeleteBuyerAsync(int id)
        {
            var deleteBuyer = await _buyerServices.DeleteBuyerAsync(id);
            if (deleteBuyer == null)
            {
                return NotFound();
            }
            return Ok(deleteBuyer);
        }

        [HttpPut]
        public async Task<ActionResult<ReadBuyerDto>> UpdateBuyerAsync(int id, UpdateBuyerDto updateBuyerDto)
        {
            var updatedBuyer=await _buyerServices.UpdateBuyerAsync(id, updateBuyerDto);
            if(updatedBuyer == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            return Ok(updatedBuyer);
        }
    }
}
