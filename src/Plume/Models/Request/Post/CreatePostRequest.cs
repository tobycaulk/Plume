using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Request.Post
{
    public class CreatePostRequest
    {
        public string AccountId { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
