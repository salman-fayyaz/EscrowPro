using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface ISellerService
    {
        Task CreateSellerAsync(CreateSellerDto createSellerDto);

        Task<IEnumerable<ReadSellerDto>> GetAllSellersAsync();

        Task<ReadSellerDto> GetSellerByIdAsync(int id);

        Task<UpdateSellerDto> UpdateSellerAsync(int id, UpdateSellerDto updatesellerDto);

        Task<ReadSellerDto> DeleteSellerAsync(int id);

    }
}
