using Plume.Models.Request.Post;
using Plume.Models.Response.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Service.Post
{
    public interface IPostService
    {
        CreatePostResponse Create(CreatePostRequest request);
        GetPostByPostIdResponse GetByPostId(GetPostByPostIdRequest request);
        GetPostByAccountIdResponse getByAccountId(GetPostByAccountIdRequest request);
        UpdatePostLikeCountResponse UpdatePostLikeCount(UpdatePostLikeCountRequest request);
    }
}
