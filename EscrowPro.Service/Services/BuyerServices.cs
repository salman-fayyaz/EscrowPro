using System;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;

namespace EscrowPro.Service.Services
{
    public class BuyerServices : IBuyerServices
    {
        public Task<BuyerCreateDto> CreateBuyerAsync(BuyerCreateDto buyerCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBuyerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuyerReadDto>> GetAllBuyersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BuyerReadDto> GetBuyerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BuyerUpdateDto> UpdateBuyerAsync(int id, BuyerUpdateDto buyerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
