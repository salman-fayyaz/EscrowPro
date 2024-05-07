using System;
using System.Numerics;
using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using EscrowPro.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EscrowPro.Service.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;
        
        private readonly IMapper _mapper;

        public BuyerService(){}

        public BuyerService(IBuyerRepository buyerRepository, IMapper mapper)
        {
            _buyerRepository = buyerRepository;
            _mapper = mapper;
        }

        public async Task CreateBuyerAsync(CreateBuyerDto createBuyerDto)
        {
            if (createBuyerDto == null)
            {
                throw new ArgumentNullException(null);
            }
            var buyer = _mapper.Map<Buyer>(createBuyerDto);
            await _buyerRepository.CreateBuyerAsync(buyer);
        }

        public async Task<ReadBuyerDto> DeleteBuyerAsync(int id)
        {
            if(id == null || id <= 0)
            {
                throw new ArgumentNullException("id"); 
            }
            var buyer = await _buyerRepository.DeleteBuyerAsync(id);
            if (buyer == null)
            {
                return null;
            }
            return _mapper.Map<ReadBuyerDto>(buyer);
             
        }

        public async Task<IEnumerable<ReadBuyerDto>> GetAllBuyersAsync()
        {
            var allBuyers = await _buyerRepository.GetAllBuyersAsync();
            var buyers = _mapper.Map<List<ReadBuyerDto>>(allBuyers);
            return buyers;
        }

        public async Task<ReadBuyerDto> GetBuyerByIdAsync(int id)
        {
            if(id == null || id <=0)
            {
                throw new ArgumentNullException("id");
            }
            var existBuyer = await _buyerRepository.GetBuyerByIdAsync(id);
            var foundBuyer = _mapper.Map<ReadBuyerDto>(existBuyer);
            return foundBuyer;
        }

        public async Task<UpdateBuyerDto> UpdateBuyerAsync(int id, UpdateBuyerDto updateBuyerDto)
        {
            //ReadDtoMustUseIT,/..........THinkIt
            if(id==null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var buyerModel = _mapper.Map<Buyer>(updateBuyerDto);
            var buyer = _buyerRepository.UpdateBuyerAsync(id, buyerModel);
            var buyerDto=_mapper.Map<UpdateBuyerDto>(buyer);
            return buyerDto;
        }
    }
}
