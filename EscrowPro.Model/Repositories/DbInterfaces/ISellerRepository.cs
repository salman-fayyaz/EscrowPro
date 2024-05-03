using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface ISellerRepository
    {
        Task CreateSellerAsync(Seller seller);

        Task<IEnumerable<Seller>> GetAllSellerAsync();

        Task<Seller> GetSellerByIdAsync(int id);

        Task<Seller> UpdateSellerAsync(int id, Seller seller);

        Task<Seller> DeleteSellerAsync(int id);

        Task<string> VerifyTokenExist(string token);

    }
}
