using EscrowPro.Core.Dtos;
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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly EscrowProContext _context;

        public TransactionRepository(EscrowProContext escrowProContext)
        {
            _context = escrowProContext;
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction.SellerId.HasValue  && transaction.BuyerId==null)
            {
                var newTransaction = new Transaction
                {
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                   // BuyerId = transaction.BuyerId,
                    SellerId = transaction.SellerId,
                    StartDate = DateTime.Now,
                };
                await _context.Transactions.AddAsync(newTransaction);
                await _context.SaveChangesAsync();
            }
            if (transaction.BuyerId.HasValue && transaction.SellerId==null)
            {
                var newTransaction = new Transaction
                {
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                    BuyerId = transaction.BuyerId,
                    //SellerId = transaction.SellerId,
                    StartDate = DateTime.Now,
                };
                await _context.Transactions.AddAsync(newTransaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Transaction> DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return null;
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
