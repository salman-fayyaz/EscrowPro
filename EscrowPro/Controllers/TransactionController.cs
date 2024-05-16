﻿using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionServices;

        public TransactionController(ITransactionService transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransactionAsync([FromBody] CreateTransactionDto createTransactionDto)
        {
            var userId = await _transactionServices.CreateTransactionAsync(createTransactionDto);
            return Ok(userId);
        }

        [HttpGet]
        public async Task<ActionResult<ReadTransactionDto>> GetAllTransactionsAsync()
        {
             await _transactionServices.GetAllTransactionsAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTransactionDto>> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionServices.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadTransactionDto>> DeleteTransactionAsync(int id)
        {
            var deleteTransaction = await _transactionServices.DeleteTransactionAsync(id);
            if (deleteTransaction == null)
            {
                return NotFound();
            }
            return Ok(deleteTransaction);
        }

        [HttpPut]
        public async Task<ActionResult<ReadTransactionDto>> UpdateTransactionAsync(int id, UpdateTransactionDto updateTransactionDto)
        {
            var updatedTransaction = await _transactionServices.UpdateTransactionAsync(id, updateTransactionDto);
            if (updatedTransaction == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return Ok(updatedTransaction);
        }
    }
}