using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EscrowPro.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly EscrowProContext _context;

        private readonly IMapper _mapper;

        private readonly IBuyerService _buyerService;

        public BuyerRepository(EscrowProContext escrowProContext, IMapper mapper)
        {
            _context = escrowProContext;
            _mapper = mapper;
        }

        public Task BuyProductAsync(int buyerId, string sellerToken)
        {
            throw new NotImplementedException();
        }

        public async Task CreateBuyerAsync(Buyer buyer)
        { 
            await _context.Buyers.AddAsync(buyer);
            await _context.SaveChangesAsync();
        }

        public async Task<Buyer> DeleteBuyerAsync(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null)
            {
               return null;
            }
            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            return await _context.Buyers.ToListAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int id)
        {
            return await _context.Buyers.FindAsync(id);
        }

        public async Task<Buyer> UpdateBuyerAsync(int id, Buyer buyer)
        {
            var existBuyer = await _context.Buyers.FindAsync(id);
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            existBuyer.Id = id;
            existBuyer.Name = buyer.Name;
            existBuyer.Email = buyer.Email;
            existBuyer.Phone = buyer.Phone;
            existBuyer.Password = buyer.Password;
            existBuyer.ConfirmPassword=buyer.ConfirmPassword;
            existBuyer.CNIC = buyer.CNIC;
            await _context.SaveChangesAsync();
            return existBuyer;
        }
    }
}
