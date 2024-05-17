using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.Profiles
{
    public class SellerProfile:Profile
    {
        public SellerProfile()
        {
            CreateMap<Seller, ReadSellerDto>();
            CreateMap<CreateSellerDto, Seller>();
            CreateMap<UpdateSellerDto, Seller>();
            CreateMap<Seller, UpdateSellerDto>();
        }
    }
}
