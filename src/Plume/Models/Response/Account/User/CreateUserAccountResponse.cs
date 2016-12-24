using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response.Account.User
{
    public class CreateUserAccountResponse
    {
        public enum ResponseStatus
        {
            SUCCESS,
            ACCOUNT_ALREADY_EXISTS,
            INTERNAL_ERROR
        }

        public string Status { get; set; }

        public void SetStatus(ResponseStatus status)
        {
            Status = status.ToString();
        }
    }
}
