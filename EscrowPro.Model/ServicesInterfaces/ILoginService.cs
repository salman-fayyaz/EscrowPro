using EscrowPro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.ServicesInterfaces
{
    public interface ILoginService
    {
        Task<(Boolean, string, int)> CheckLoginStatusAsync(CreateLoginDto createLoginDto);
    }
}
