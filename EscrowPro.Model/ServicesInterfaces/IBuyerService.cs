using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface IBuyerService
    {
        Task  CreateBuyerAsync(CreateBuyerDto buyerCreateDto);

        Task<IEnumerable<ReadBuyerDto>> GetAllBuyersAsync();

        Task<ReadBuyerDto> GetBuyerByIdAsync(int id);

        Task<UpdateBuyerDto> UpdateBuyerAsync(int id, UpdateBuyerDto updateBuyerDto);

        Task<ReadBuyerDto> DeleteBuyerAsync(int id);

        //Task BuyProductAsync(int buyerId, string sellerToken);
        
    }
}
