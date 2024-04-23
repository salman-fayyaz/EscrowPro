using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface IBuyerService
    {
        Task<CreateBuyerDto> CreateBuyerAsync(CreateBuyerDto buyerCreateDto);

        Task<IEnumerable<ReadBuyerDto>> GetAllBuyersAsync();

        Task<List<ReadBuyerDto>> GetBuyerByIdAsync(int id);

        Task<List<UpdateBuyerDto>> UpdateBuyerAsync(int id, UpdateBuyerDto buyerUpdateDto);

        Task<List<ReadBuyerDto>> DeleteBuyerAsync(int id);

        
    }
}
