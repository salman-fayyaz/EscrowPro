using EscrowPro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface IBuyerFormService
    {
        Task CreateBuyerFormAsync(CreateBuyerFormDto buyerCreateFormDto);

        Task<IEnumerable<ReadBuyerFormDto>> GetAllBuyerFormsAsync();

        Task<ReadBuyerFormDto> GetBuyerFormByIdAsync(int id);

        Task<UpdateBuyerFormDto> UpdateBuyerFormAsync(int id, UpdateBuyerFormDto updateBuyerFormDto);

        Task<ReadBuyerFormDto> DeleteBuyerFormAsync(int id);
    }
}
