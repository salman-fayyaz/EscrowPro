using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface IBuyerFormRepository
    {
        Task CreateBuyerFormAsync(BuyerForm buyerForm);

        Task<IEnumerable<BuyerForm>> GetAllBuyerFormsAsync();

        Task<BuyerForm> GetBuyerFormByIdAsync(int id);

        Task<BuyerForm> UpdateBuyerFormAsync(int id, BuyerForm buyerForm);

        Task<BuyerForm> DeleteBuyerFormAsync(int id);
    }
}
