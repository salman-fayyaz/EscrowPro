using EscrowPro.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface ILoginRepository
    {
        Task<(Boolean, string, int)> CheckLoginStatusAsync(Login login);
    }
}
