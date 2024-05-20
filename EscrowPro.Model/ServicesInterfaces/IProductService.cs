using EscrowPro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);

        Task<IEnumerable<ReadProductDto>> GetAllProductsAsync();

        Task<ReadProductDto> GetProductByIdAsync(int id);

        Task<UpdateProductDto> UpdateProductAsync(int id, UpdateProductDto updateProductDto);

        Task<ReadProductDto> DeleteProductAsync(int id);
    }
}
