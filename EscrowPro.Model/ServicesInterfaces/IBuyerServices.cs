using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface IBuyerServices
    {
        Task<BuyerCreateDto> CreateBuyerAsync(BuyerCreateDto buyerCreateDto);

        Task<IEnumerable<BuyerReadDto>> GetAllBuyersAsync();

        Task<BuyerReadDto> GetBuyerByIdAsync(int id);

        Task<BuyerUpdateDto> UpdateBuyerAsync(int id, BuyerUpdateDto buyerUpdateDto);

        Task<List<BuyerReadDto>> DeleteBuyerAsync(int id);

        
    }
}
