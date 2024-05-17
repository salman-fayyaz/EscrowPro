using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerFormController : ControllerBase
    {
        private readonly IBuyerFormService _buyerFormServices;

        public BuyerFormController(IBuyerFormService buyerFormService)
        {
            _buyerFormServices = buyerFormService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBuyerFormAsync([FromBody] CreateBuyerFormDto createBuyerFormDto)
        {
            await _buyerFormServices.CreateBuyerFormAsync(createBuyerFormDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReadBuyerFormDto>> GetAllBuyersFormAsync()
        {
            var buyerForms = await _buyerFormServices.GetAllBuyerFormsAsync();
            return Ok(buyerForms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadBuyerFormDto>> GetBuyerFormByIdAsync(int id)
        {
            var buyerForm = await _buyerFormServices.GetBuyerFormByIdAsync(id);
            if (buyerForm == null)
            {
                return NotFound();
            }
            return Ok(buyerForm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadBuyerFormDto>> DeleteBuyerFormAsync(int id)
        {
            var deleteBuyerForm = await _buyerFormServices.DeleteBuyerFormAsync(id);
            if (deleteBuyerForm == null)
            {
                return NotFound();
            }
            return Ok(deleteBuyerForm);
        }
    }
}
