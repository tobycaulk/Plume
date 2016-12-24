using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Request.Post
{
    public class UpdatePostLikeCountRequest
    {
        public string AccountId { get; set; }
        public string PostId { get; set; }
        public int LikeCountModification { get; set; }
    }
}
