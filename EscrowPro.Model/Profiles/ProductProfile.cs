using System;
using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;

namespace EscrowPro.Core.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
