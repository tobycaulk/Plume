using Microsoft.AspNetCore.Mvc;
using Plume.Models.Request;
using Plume.Models.Request.Account.User;
using Plume.Models.Response.Account.User;
using Plume.Service;
using Plume.Service.Account.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Controllers
{
    [Route("api/[controller]")]
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] BaseRequest<CreateUserAccountRequest> request)
        {
            return new ServiceExecutor<CreateUserAccountRequest, CreateUserAccountResponse>().call(request, (req) => _userAccountService.Create((CreateUserAccountRequest) request.Payload));
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody] BaseRequest<AuthenticateUserAccountRequest> request)
        {
            return new ServiceExecutor<AuthenticateUserAccountRequest, AuthenticateUserAccountResponse>().call(request, (req) => _userAccountService.Authenticate((AuthenticateUserAccountRequest) request.Payload));
        }
    }
}
