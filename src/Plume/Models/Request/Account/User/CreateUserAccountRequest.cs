using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Request.Account.User
{
    public class CreateUserAccountRequest
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
    }
}
