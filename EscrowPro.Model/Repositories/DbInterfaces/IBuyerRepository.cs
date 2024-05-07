using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface IBuyerRepository
    {
        Task  CreateBuyerAsync(Buyer buyer);

        Task<IEnumerable<Buyer>> GetAllBuyersAsync();

        Task<Buyer> GetBuyerByIdAsync(int id);

        Task<Buyer> UpdateBuyerAsync(int id, Buyer buyer);

        Task<Buyer> DeleteBuyerAsync(int id);
    }
}
