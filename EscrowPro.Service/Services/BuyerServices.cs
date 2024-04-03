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

        public async Task<List<BuyerReadDto>> DeleteBuyerAsync(int id)
        {
            var deleteBuyer = new List<BuyerReadDto>();
            var existId = await _context.Buyers.FindAsync(id);
            if (existId == null)
            {
                return null;
            }
            _context.Buyers.Remove(existId);
            await _context.SaveChangesAsync();
            var existingBuyer = new BuyerReadDto
            {
                Id=existId.Id,
                Name=existId.Name,
                Email=existId.Email,
                CNIC=existId.CNIC,
                Phone=existId.Phone,         
            };
            deleteBuyer.Add(existingBuyer);
            return deleteBuyer;
        }

        public async Task<IEnumerable<BuyerReadDto>> GetAllBuyersAsync()
        {
            var buyersDtoList=new List<BuyerReadDto>();
            var buyers= await _context.Buyers.ToListAsync();
            foreach (var buyer in buyers)
            {
                var dtoBuyer = new BuyerReadDto
                {
                    Id=buyer.Id,
                    Name=buyer.Name,
                    Email=buyer.Email,
                    CNIC=buyer.CNIC,
                    Phone=buyer.Phone,
                };
                buyersDtoList.Add(dtoBuyer);
            }
            return buyersDtoList;
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
