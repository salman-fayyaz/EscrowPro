using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Repositories;

namespace EscrowPro.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly IMapper _mapper;

        bool transactionCreatedByBuyer = false;

        bool transactionCreatedBySeller = false;

        public TransactionService() {}

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper=mapper;

        }

        public async Task<int> CreateTransactionAsync(CreateTransactionDto createTransactionDto)
        {
            if (createTransactionDto == null)
            {
                throw new ArgumentNullException(null);
            }
            if (createTransactionDto.SellerId.HasValue && createTransactionDto.BuyerId==0)
            {
                var newTransactionDto = new CreateTransactionDto
                {
                    Amount = createTransactionDto.Amount,
                    Description = createTransactionDto.Description,
                   // BuyerId = createTransactionDto.BuyerId,
                    SellerId = createTransactionDto.SellerId,
                };
                var transaction = _mapper.Map<Transaction>(newTransactionDto);
                await _transactionRepository.CreateTransactionAsync(transaction);
                int id = (int)transaction.SellerId;
                return id;
            }
            if (createTransactionDto.BuyerId.HasValue && createTransactionDto.SellerId==0)
            {
                var newTransactionDto = new CreateTransactionDto
                {
                    Amount = createTransactionDto.Amount,
                    Description = createTransactionDto.Description,
                    BuyerId = createTransactionDto.BuyerId,
                    //SellerId = createTransactionDto.SellerId,
                };
                var transaction = _mapper.Map<Transaction>(newTransactionDto);
                await _transactionRepository.CreateTransactionAsync(transaction);
                int id = (int)transaction.BuyerId;
                return id;
            }
            return 0;
        }

        public async Task<ReadTransactionDto> DeleteTransactionAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var transaction = await _transactionRepository.DeleteTransactionAsync(id);
            if (transaction == null)
            {
                return null;
            }
            return _mapper.Map<ReadTransactionDto>(transaction);
        }

        public async Task<IEnumerable<ReadTransactionDto>> GetAllTransactionsAsync()
        {
            var allTransactions = await _transactionRepository.GetAllTransactionsAsync();
            var transactions = _mapper.Map<List<ReadTransactionDto>>(allTransactions);
            return transactions;
        }

        public async Task<ReadTransactionDto> GetTransactionByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var existTransaction = await _transactionRepository.GetTransactionByIdAsync(id);
            var foundTransaction = _mapper.Map<ReadTransactionDto>(existTransaction);
            return foundTransaction;
        }

        public Task<UpdateTransactionDto> UpdateTransactionAsync(int id, UpdateTransactionDto updateTransactionDto)
        {
            throw new NotImplementedException();
        }
    }
}
