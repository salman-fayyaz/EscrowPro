using EscrowPro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface ISellerService
    {
        Task<CreateSellerDto> CreateSellerAsync(CreateSellerDto CreateSellerDto);

        Task<IEnumerable<ReadSellerDto>> GetAllSellersAsync();

        Task<List<ReadSellerDto>> GetSellerByIdAsync(int id);

        Task<List<UpdateSellerDto>> UpdateSellerAsync(int id, UpdateSellerDto buyerSellerDto);

        Task<List<ReadSellerDto>> DeleteSellerAsync(int id);

        Task SellProductAsync(int sellerId, CreateProductDto createProductDto);
    }
}
