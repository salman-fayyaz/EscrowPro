using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.Profiles
{
    public class BuyerProfile:Profile
    {
        public BuyerProfile()
        {
            CreateMap<Buyer,ReadBuyerDto>();
            CreateMap<CreateBuyerDto, Buyer>();
            CreateMap<UpdateBuyerDto,Buyer>();
        }
    }
}
