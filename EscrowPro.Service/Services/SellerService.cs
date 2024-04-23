using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
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

        public Task<List<ReadSellerDto>> DeleteSellerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadSellerDto>> GetAllSellersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReadSellerDto>> GetSellerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpdateSellerDto>> UpdateSellerAsync(int id, UpdateSellerDto buyerSellerDto)
        {
            throw new NotImplementedException();
        }
    }
}
