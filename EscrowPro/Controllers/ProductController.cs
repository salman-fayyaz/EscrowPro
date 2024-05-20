using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReadProductDto>> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadProductDto>> DeleteProductAsync(int id)
        {
            var deleteProduct = await _productService.DeleteProductAsync(id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            return Ok(deleteProduct);
        }

        [HttpPut]
        public async Task<ActionResult<ReadProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var updateProduct = await _productService.UpdateProductAsync(id, updateProductDto);
            if (updateProduct == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            return Ok(updateProduct);
        }
    }
}
