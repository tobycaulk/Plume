using Plume.Models.Request.Account.User;
using Plume.Models.Response.Account.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Service.Account.User
{
    public interface IUserAccountService
    {
        AuthenticateUserAccountResponse Authenticate(AuthenticateUserAccountRequest request);
        CreateUserAccountResponse Create(CreateUserAccountRequest request);
    }
}
