using CSP.Users.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CSP.Users.Contract;

namespace CSP.Users.Services
{
    public interface IUserService
    {
        List<User> GetUsers(int page, int pageSize);
    }
}
