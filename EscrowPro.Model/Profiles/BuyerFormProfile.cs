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
    public class BuyerFormProfile:Profile
    {
        public BuyerFormProfile()
        {
            CreateMap<BuyerForm, ReadBuyerFormDto>();
            CreateMap<CreateBuyerFormDto, BuyerForm>();
            CreateMap<UpdateBuyerFormDto, BuyerForm>();
            CreateMap<BuyerForm, UpdateBuyerFormDto>();
        }
    }
}
