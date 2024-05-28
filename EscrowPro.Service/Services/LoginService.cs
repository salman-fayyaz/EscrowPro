using AutoMapper;
using EscrowPro.Core.Dtos;
using EscrowPro.Core.Models;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepostory;

        private IMapper _mapper;

        public LoginService(ILoginRepository loginRepository,IMapper mapper)
        {
            _loginRepostory=loginRepository;
            _mapper=mapper;
        }

        public async Task<(Boolean,string,int)> CheckLoginStatusAsync(CreateLoginDto createLoginDto)
        {
            if (createLoginDto == null)
            {
                throw new ArgumentNullException();
            }
            var userLogin = _mapper.Map<Login>(createLoginDto);
            var login = await _loginRepostory.CheckLoginStatusAsync(userLogin);
            return login;
        }
    }
}
