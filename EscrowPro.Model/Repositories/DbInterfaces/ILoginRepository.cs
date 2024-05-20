using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Repositories.DbInterfaces
{
    public interface ILoginRepository
    {
        Task CheckUserExist(string email,string password);
    }
}
