using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly EscrowProContext _context;

        private readonly IMapper _mapper;

        private readonly ISellerService _sellerService;

        public SellerRepository(EscrowProContext escrowProContext, IMapper mapper)
        {
            _context = escrowProContext;
            _mapper = mapper;
        }

        public async Task CreateSellerAsync(Seller seller)
        {
            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> DeleteSellerAsync(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return null;
            }
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task<IEnumerable<Seller>> GetAllSellerAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            return await _context.Sellers.FindAsync(id);
        }

        public async Task<Seller> UpdateSellerAsync(int id, Seller seller)
        {
            var existSeller = await _context.Sellers.FindAsync(id);
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            existSeller.Id = id;
            existSeller.Name = seller.Name;
            existSeller.Email = seller.Email;
            existSeller.Phone = seller.Phone;
            existSeller.Password = seller.Password;
            existSeller.ConfirmPassword = seller.ConfirmPassword;
            existSeller.CNIC = seller.CNIC;
            await _context.SaveChangesAsync();
            return existSeller;
        }
    }
}
