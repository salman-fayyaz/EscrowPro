using EscrowPro.Core.Repositories.DbInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Task CheckUserExist(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
