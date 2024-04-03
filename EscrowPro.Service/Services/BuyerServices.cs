using System;
using System.Numerics;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public async Task<List<BuyerReadDto>> GetBuyerByIdAsync(int id)
        {
            var foundBuyerList = new List<BuyerReadDto>();
            var findId = await _context.Buyers.FindAsync(id);
            if(findId == null)
            {
                return null;
            }
            var buyerDto = new BuyerReadDto
            {
                Id = findId.Id,
                Name = findId.Name,
                Email=findId.Email,
                CNIC=findId.CNIC,
                Phone=findId.Phone,
            };

            foundBuyerList.Add(buyerDto);
            return foundBuyerList;
        }

        public async Task<List<BuyerUpdateDto>> UpdateBuyerAsync(int id, BuyerUpdateDto buyerUpdateDto)
        {
            var updatedbuyerList = new List<BuyerUpdateDto>();
            var updateBuyer = await _context.Buyers.FindAsync(id);
            if (updateBuyer == null)
            {
                return null;
            }
            updateBuyer.Id = id;
            updateBuyer.Name = buyerUpdateDto.Name;
            updateBuyer.Email= buyerUpdateDto.Email;
            updateBuyer.Password= buyerUpdateDto.Password;
            updateBuyer.ConfirmPassword= buyerUpdateDto.ConfirmPassword;
            updateBuyer.Phone= buyerUpdateDto.Phone;
            updateBuyer.CNIC= buyerUpdateDto.CNIC;
            var updatedBuyer = new BuyerUpdateDto
            {
                Name=updateBuyer.Name,
                Email=updateBuyer.Email,
                Phone=updateBuyer.Phone,
                CNIC=updateBuyer.CNIC,
                Password=updateBuyer.Password,
                ConfirmPassword=updateBuyer.ConfirmPassword,
            };
            updatedbuyerList.Add(updatedBuyer);
            return updatedbuyerList;
        }
    }
}
