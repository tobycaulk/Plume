using Plume.Models.Mongo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response.Post
{
    public class GetPostByAccountIdResponse
    {
        public IEnumerable<PostDAO> Posts { get; set; }
    }
}
