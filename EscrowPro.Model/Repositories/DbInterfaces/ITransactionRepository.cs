using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface ITransactionRepository
    {
        Task<string> CreateTransactionAsync(Transaction transaction);

        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task<Transaction> GetTransactionByIdAsync(int id);

        Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction);

        Task<Transaction> DeleteTransactionAsync(int id);

        Task<Transaction> GetTransactionByTokenAsync(string token);

        Task<Transaction> GetTransactionByUserRoleAsync(string role, int id);
    }
}
