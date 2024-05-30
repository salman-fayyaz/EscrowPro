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

        public async Task<string> CreateTransactionAsync(Transaction transaction)
        {
            string token;
            do
            {
                token = Guid.NewGuid().ToString();
            } while (await _context.Transactions.AnyAsync(t => t.Token == token));

            if (transaction.SellerId.HasValue  && transaction.BuyerId==null)
            {
                var newTransaction = new Transaction
                {
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                    SellerId = transaction.SellerId,
                    Token=token,
                    StartDate = DateTime.Now,
                };
                await _context.Transactions.AddAsync(newTransaction);
                await _context.SaveChangesAsync();
                return token;
            }
            if (transaction.BuyerId.HasValue && transaction.SellerId==null)
            {
                var newTransaction = new Transaction
                {
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                    BuyerId=transaction.BuyerId,
                    Token=token,
                    StartDate = DateTime.Now,
                };
                await _context.Transactions.AddAsync(newTransaction);
                await _context.SaveChangesAsync();
                return token;
            }
            return "Repository Error";
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

        public async Task<Transaction> GetTransactionByTokenAsync(string token)
        {
            if(token== null)
            {
                throw new ArgumentNullException(null);
            }
            var foundTransaction = await  _context.Transactions.FirstOrDefaultAsync(t => t.Token == token);
            if (foundTransaction == null)
            {
                throw new ArgumentNullException(null);
            }
            return foundTransaction;
        }

        public async Task<Transaction> GetTransactionByUserRoleAsync(string role,int id)
        {
            if (id == null && role == null)
            {
                throw new ArgumentNullException(null);
            }
            if (role == "Buyer")
            {
                return await _context.Transactions.FirstOrDefaultAsync(b=>b.BuyerId==id);
            }
            if (role == "Seller")
            {
                return await _context.Transactions.FirstOrDefaultAsync(s=>s.SellerId==id);
            }
            throw new ArgumentException("Invalid role", nameof(role));
        }

        public Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
