using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response.Post
{
    public class UpdatePostLikeCountResponse
    {
        public enum ResponseStatus
        {
            SUCCESS, 
            INTERNAL_ERROR
        }

        public string Status { get; set; }

        public void SetStatus(ResponseStatus status)
        {
            Status = status.ToString();
        }
    }
}
