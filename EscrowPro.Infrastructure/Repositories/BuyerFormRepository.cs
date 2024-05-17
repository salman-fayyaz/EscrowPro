using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Infrastructure.Repositories
{
    public class BuyerFormRepository:IBuyerFormRepository
    {
        private readonly EscrowProContext _context;

        public BuyerFormRepository(EscrowProContext context)
        {
            _context = context;
        }

        public async Task CreateBuyerFormAsync(BuyerForm buyerForm)
        {
            var newBuyerForm = new BuyerForm
            {
                HouseNo=buyerForm.HouseNo,
                Street=buyerForm.Street,
                Area=buyerForm.Area,
                City=buyerForm.City,
                ZipCode=buyerForm.ZipCode,
                CountryState=buyerForm.CountryState,
                CNICBuyer=buyerForm.CNICBuyer,
                CnicImage=buyerForm.CnicImage,
                KycImage=buyerForm.KycImage
            };
            await _context.BuyerForms.AddAsync(newBuyerForm);
            await _context.SaveChangesAsync();
        }

        public async Task<BuyerForm> DeleteBuyerFormAsync(int id)
        {
            var buyerForm = await _context.BuyerForms.FindAsync(id);
            if (buyerForm == null)
            {
                return null;
            }
            _context.BuyerForms.Remove(buyerForm);
            await _context.SaveChangesAsync();
            return buyerForm;
        }

        public async Task<IEnumerable<BuyerForm>> GetAllBuyerFormsAsync()
        {
            return await _context.BuyerForms.ToListAsync();
        }

        public async Task<BuyerForm> GetBuyerFormByIdAsync(int id)
        {
            return await _context.BuyerForms.FindAsync(id);
        }

        public Task<BuyerForm> UpdateBuyerFormAsync(int id, BuyerForm buyerForm)
        {
            throw new NotImplementedException();
        }
    }
}
