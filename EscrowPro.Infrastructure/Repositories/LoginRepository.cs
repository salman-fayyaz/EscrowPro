using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EscrowProContext _context;

        public LoginRepository(EscrowProContext escrowProContext)
        {
            _context = escrowProContext;
        }

        public async Task<(Boolean,string,int)> CheckLoginStatusAsync(Login login)
        {
            if (login == null) throw new ArgumentNullException();
            if (login.status == "Buyer")
            {
                var buyer = _context.Buyers.FirstOrDefault(l=>l.Email==login.Email&&l.Password==login.Password);
                if(buyer != null)
                {
                    await _context.Logins.AddAsync(login);
                    await _context.SaveChangesAsync();
                    string userStatus = "Buyer";
                    return (true,userStatus,buyer.Id);
                }
                else
                {
                    return (false,"", 0);
                }
            }
            if (login.status == "Seller")
            {
                var seller = _context.Sellers.FirstOrDefault(l => l.Email == login.Email && l.Password == login.Password);
                if(seller!= null)
                {
                    await _context.Logins.AddAsync(login);
                    await _context.SaveChangesAsync();
                    string userStatus = "Seller";
                    return (true, userStatus, seller.Id);
                }
                else
                {
                    return (false,"",0);
                }
            }
            return (false,"",0);
        }
    }
}
