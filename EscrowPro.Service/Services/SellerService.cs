using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using EscrowPro.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;

namespace EscrowPro.Service.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task CreateSellerAsync(CreateSellerDto createSellerDto)
        {
            if (createSellerDto == null)
            {
                throw new ArgumentNullException(null);
            }
            var seller = _mapper.Map<Seller>(createSellerDto);
            await _sellerRepository.CreateSellerAsync(seller);
        }

        public async Task<ReadSellerDto> DeleteSellerAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var seller = await _sellerRepository.DeleteSellerAsync(id);
            if (seller == null)
            {
                return null;
            }
            return _mapper.Map<ReadSellerDto>(seller);
        }

        public async Task<IEnumerable<ReadSellerDto>> GetAllSellersAsync()
        { 
            var allSellers = await _sellerRepository.GetAllSellerAsync();
            var sellers = _mapper.Map<List<ReadSellerDto>>(allSellers);
            return sellers;
        }

        public async Task<ReadSellerDto> GetSellerByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var existSeller = await _sellerRepository.GetSellerByIdAsync(id);
            var foundSeller = _mapper.Map<ReadSellerDto>(existSeller);
            return foundSeller;
        }

        public async Task<UpdateSellerDto> UpdateSellerAsync(int id, UpdateSellerDto updatesellerDto)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var sellerModel = _mapper.Map<Seller>(updatesellerDto);
            var seller = _sellerRepository.UpdateSellerAsync(id, sellerModel);
            var sellerDto = _mapper.Map<UpdateSellerDto>(seller);
            return sellerDto;
        }
    }
}
