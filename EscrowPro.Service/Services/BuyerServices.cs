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

        public async Task<CreateBuyerDto> CreateBuyerAsync(CreateBuyerDto buyerCreateDto)
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

        public async Task<List<ReadBuyerDto>> DeleteBuyerAsync(int id)
        {
            var deleteBuyer = new List<ReadBuyerDto>();
            var existId = await _context.Buyers.FindAsync(id);
            if (existId == null)
            {
                return null;
            }
            _context.Buyers.Remove(existId);
            await _context.SaveChangesAsync();
            var existingBuyer = new ReadBuyerDto
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

        public async Task<IEnumerable<ReadBuyerDto>> GetAllBuyersAsync()
        {
            var buyersDtoList=new List<ReadBuyerDto>();
            var buyers= await _context.Buyers.ToListAsync();
            foreach (var buyer in buyers)
            {
                var dtoBuyer = new ReadBuyerDto
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

        public async Task<List<ReadBuyerDto>> GetBuyerByIdAsync(int id)
        {
            var foundBuyerList = new List<ReadBuyerDto>();
            var findId = await _context.Buyers.FindAsync(id);
            if(findId == null)
            {
                return null;
            }
            var buyerDto = new ReadBuyerDto
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

        public async Task<List<UpdateBuyerDto>> UpdateBuyerAsync(int id, UpdateBuyerDto buyerUpdateDto)
        {
            var updatedbuyerList = new List<UpdateBuyerDto>();
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
            var updatedBuyer = new UpdateBuyerDto
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
