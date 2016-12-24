using Microsoft.AspNetCore.Mvc;
using Plume.Models.Request;
using Plume.Models.Request.Post;
using Plume.Models.Response.Post;
using Plume.Service;
using Plume.Service.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] BaseRequest<CreatePostRequest> request)
        {
            return new ServiceExecutor<CreatePostRequest, CreatePostResponse>().call(request, (req) => _postService.Create((CreatePostRequest) request.Payload));
        }

        [HttpPost]
        [Route("GetByPostId")]
        public IActionResult GetByPostId([FromBody] BaseRequest<GetPostByPostIdRequest> request)
        {
            return new ServiceExecutor<GetPostByPostIdRequest, GetPostByPostIdResponse>().call(request, (req) => _postService.GetByPostId((GetPostByPostIdRequest) request.Payload));
        }

        [HttpPost]
        [Route("GetByAccountId")]
        public IActionResult GetByAccountId([FromBody] BaseRequest<GetPostByAccountIdRequest> request)
        {
            return new ServiceExecutor<GetPostByAccountIdRequest, GetPostByAccountIdResponse>().call(request, (req) => _postService.getByAccountId((GetPostByAccountIdRequest) request.Payload));
        }

        [HttpPost]
        [Route("UpdateLikeCount")]
        public IActionResult UpdateLikeCount([FromBody] BaseRequest<UpdatePostLikeCountRequest> request)
        {
            return new ServiceExecutor<UpdatePostLikeCountRequest, UpdatePostLikeCountResponse>().call(request, (req) => _postService.UpdatePostLikeCount((UpdatePostLikeCountRequest) request.Payload));
        }
    }
}
