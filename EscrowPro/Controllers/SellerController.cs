using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerServices;

        public SellerController(ISellerService sellerServices)
        {
            _sellerServices = sellerServices;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSellerAsync([FromBody] CreateSellerDto createSellerDto)
        {
            await _sellerServices.CreateSellerAsync(createSellerDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReadSellerDto>> GetAllSellersAsync()
        {
            var sellers = await _sellerServices.GetAllSellersAsync();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSellerDto>> GetSellerByIdAsync(int id)
        {
            var seller = await _sellerServices.GetSellerByIdAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadSellerDto>> DeleteSellerAsync(int id)
        {
            var deleteSeller = await _sellerServices.DeleteSellerAsync(id);
            if (deleteSeller == null)
            {
                return NotFound();
            }
            return Ok(deleteSeller);
        }

        [HttpPut]
        public async Task<ActionResult<ReadSellerDto>> UpdateSellerAsync(int id, UpdateSellerDto updateSellerDto)
        {
            var updatedSeller = await _sellerServices.UpdateSellerAsync(id, updateSellerDto);
            if (updatedSeller == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            return Ok(updatedSeller);
        }
    }
}
