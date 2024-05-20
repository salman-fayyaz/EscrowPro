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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductService(){}

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                throw new ArgumentNullException(null);
            }
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.CreateProductAsync(product);
        }

        public async Task<ReadProductDto> DeleteProductAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var product =  _productRepository.DeleteProductAsync(id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ReadProductDto>(product);
        }

        public async Task<IEnumerable<ReadProductDto>> GetAllProductsAsync()
        {
            var allProducts = await _productRepository.GetAllProductsAsync();
            var products = _mapper.Map<List<ReadProductDto>>(allProducts);
            return products;
        }

        public async Task<ReadProductDto> GetProductByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            var existProduct = await _productRepository.GetProductByIdAsync(id);
            var foundProduct = _mapper.Map<ReadProductDto>(existProduct);
            return foundProduct;
        }

        public async Task<UpdateProductDto> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
