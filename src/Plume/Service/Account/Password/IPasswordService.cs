using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Service.Account.Password
{
    public interface IPasswordService
    {
        string HashPassword(string clearTextPassword);
        bool CheckPassword(string clearTextPassword, string hashedPassword);
    }
}
