using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Service.Services
{
    public class BuyerFormService : IBuyerFormService
    {
        private readonly IBuyerFormRepository _buyerFormRepository;

        private readonly IMapper _mapper;

        public BuyerFormService(IBuyerFormRepository buyerFormRepository, IMapper mapper)
        {
            _buyerFormRepository = buyerFormRepository;
            _mapper = mapper;
        }

        public async Task CreateBuyerFormAsync(CreateBuyerFormDto buyerCreateFormDto)
        {
            if (buyerCreateFormDto== null)
            {
                throw new ArgumentNullException(null);
            }
            var buyerForm = _mapper.Map<BuyerForm>(buyerCreateFormDto);
            await _buyerFormRepository.CreateBuyerFormAsync(buyerForm);
        }

        public async Task<ReadBuyerFormDto> DeleteBuyerFormAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var buyerForm = await _buyerFormRepository.DeleteBuyerFormAsync(id);
            if (buyerForm == null)
            {
                return null;
            }
            return _mapper.Map<ReadBuyerFormDto>(buyerForm);
        }

        public async Task<IEnumerable<ReadBuyerFormDto>> GetAllBuyerFormsAsync()
        {
            var allBuyerForms = await _buyerFormRepository.GetAllBuyerFormsAsync();
            var buyerForms = _mapper.Map<List<ReadBuyerFormDto>>(allBuyerForms);
            return buyerForms;
        }

        public async Task<ReadBuyerFormDto> GetBuyerFormByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var existBuyerForm = await _buyerFormRepository.GetBuyerFormByIdAsync(id);
            var foundBuyerForm = _mapper.Map<ReadBuyerFormDto>(existBuyerForm);
            return foundBuyerForm;
        }

        public Task<UpdateBuyerFormDto> UpdateBuyerFormAsync(int id, UpdateBuyerFormDto updateBuyerFormDto)
        {
            throw new NotImplementedException();
        }
    }
}
