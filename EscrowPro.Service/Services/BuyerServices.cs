using System;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscrowPro.Service.Services
{
    public class BuyerServices : IBuyerServices
    {
        private readonly EscrowProContext _context;

        public BuyerServices(){}

        public BuyerServices(EscrowProContext escrowProContext)
        {
            _context=escrowProContext;
        }

        public async Task<BuyerCreateDto> CreateBuyerAsync(BuyerCreateDto buyerCreateDto)
        {
            if (buyerCreateDto == null)
            {
                return null;
            }
            var newBuyer = new Buyer
            {
                Name = buyerCreateDto.Name,
                Email = buyerCreateDto.Email,
                Password = buyerCreateDto.Password,
                ConfirmPassword = buyerCreateDto.ConfirmPassword,
                Phone = buyerCreateDto.Phone,
                CNIC = buyerCreateDto.CNIC
            };

            await _context.Buyers.AddAsync(newBuyer);
            await _context.SaveChangesAsync();
            return buyerCreateDto;
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
