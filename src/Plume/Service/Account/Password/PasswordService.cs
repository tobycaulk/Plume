using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Service.Account.Password
{
    public class PasswordService : IPasswordService
    {
        public bool CheckPassword(string clearTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(clearTextPassword, hashedPassword);
        }

        public string HashPassword(string clearTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(clearTextPassword);
        }
    }
}
