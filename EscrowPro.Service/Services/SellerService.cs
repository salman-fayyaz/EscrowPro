using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EscrowPro.Service.Services
{
    public class SellerService : ISellerService
    {
        private readonly EscrowProContext _context;

        public SellerService(){}

        public SellerService(EscrowProContext escrowProContext)
        {
            _context= escrowProContext;
        }
        public async Task<CreateSellerDto> CreateSellerAsync(CreateSellerDto CreateSellerDto)
        {
            if (CreateSellerDto == null)
            {
                return null;
            }
            var newSeller = new Seller
            {
                Name=CreateSellerDto.Name,
                Email=CreateSellerDto.Email,
                Password=CreateSellerDto.Password,
                ConfirmPassword=CreateSellerDto.ConfirmPassword,
                CNIC=CreateSellerDto.CNIC,
                Phone= CreateSellerDto.Phone,
                RegistrationDate=DateTime.Now
            };
            await _context.Sellers.AddAsync(newSeller);
            await _context.SaveChangesAsync();
            return CreateSellerDto;

        }

        public async Task<List<ReadSellerDto>> DeleteSellerAsync(int id)
        {
            var deleteSeller = new List<ReadSellerDto>();
            var existId = await _context.Sellers.FindAsync(id);
            if (existId == null)
            {
                return null;
            }
            _context.Sellers.Remove(existId);
            await _context.SaveChangesAsync();
            var existSeller = new ReadSellerDto
            {
                Id = existId.Id,
                Name = existId.Name,
                Email = existId.Email,
                CNIC = existId.CNIC,
                Phone = existId.Phone,
            };
            deleteSeller.Add(existSeller);
            return deleteSeller;
        }

        public async Task<IEnumerable<ReadSellerDto>> GetAllSellersAsync()
        {
            var sellersList = new List<ReadSellerDto>();
            var allSellers = await _context.Sellers.ToListAsync();
            foreach(var seller in allSellers)
            {
                var sellerDto = new ReadSellerDto
                {
                    Id=seller.Id,
                    Name=seller.Name,
                    Email=seller.Email,
                    Phone=seller.Phone,
                    CNIC=seller.CNIC,
                };
                sellersList.Add(sellerDto);
            }
            return sellersList;
        }

        public async Task<List<ReadSellerDto>> GetSellerByIdAsync(int id)
        {
            var sellerList = new List<ReadSellerDto>();
            var foundSeller = await _context.Sellers.FindAsync(id);
            if(foundSeller==null)
            {
                return null;
            }
            var sellerDto = new ReadSellerDto
            {
                Id=foundSeller.Id,
                Name= foundSeller.Name,
                Email= foundSeller.Email,
                Phone=foundSeller.Phone,
                CNIC=foundSeller.CNIC
            };
            sellerList.Add(sellerDto);
            return sellerList;
        }

        public Task<List<UpdateSellerDto>> UpdateSellerAsync(int id, UpdateSellerDto buyerSellerDto)
        {
            throw new NotImplementedException();
        }
    }
}
