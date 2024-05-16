using EscrowPro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface ITransactionService
    {
        Task<(int,string,string)> CreateTransactionAsync(CreateTransactionDto createTransactionDto);

        Task<IEnumerable<ReadTransactionDto>> GetAllTransactionsAsync();

        Task<ReadTransactionDto> GetTransactionByIdAsync(int id);

        Task<UpdateTransactionDto> UpdateTransactionAsync(int id, UpdateTransactionDto updateTransactionDto);

        Task<ReadTransactionDto> DeleteTransactionAsync(int id);

        Task<ReadTransactionDto> GetTransactionByToken(string token);
    }
}
