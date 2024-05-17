using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Profiles
{
    public class SellerFormProfile:Profile
    {
        public SellerFormProfile()
        {
            CreateMap<SellerForm, ReadSellerFormDto>();
            CreateMap<CreateSellerFormDto, SellerForm>();
            CreateMap<UpdateSellerFormDto, SellerForm>();
            CreateMap<SellerForm, UpdateSellerFormDto>();
        }
    }
}
