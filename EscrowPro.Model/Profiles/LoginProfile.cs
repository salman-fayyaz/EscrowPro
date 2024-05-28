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
    public class LoginProfile:Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, ReadLoginDto>();
            CreateMap<CreateLoginDto, Login>();
            CreateMap<UpdateLoginDto, Login>();
            CreateMap<Login, UpdateLoginDto>();
            CreateMap<Login, UpdateLoginDto>();
        }
    }
}
