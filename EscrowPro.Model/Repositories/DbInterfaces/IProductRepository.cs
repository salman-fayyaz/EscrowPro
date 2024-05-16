using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task<Product> GetProductByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task DeleteProductAsync(int id);

        Task<Product> GetProductByTokenAsync(string token);
    }
}
