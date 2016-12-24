using Plume.Models.Mongo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response.Post
{
    public class GetPostByPostIdResponse
    {
        public PostDAO Post { get; set; }
    }
}
