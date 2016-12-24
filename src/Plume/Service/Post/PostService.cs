using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plume.Models.Request.Post;
using Plume.Models.Response.Post;
using Plume.Models.Mongo;
using AutoMapper;
using Plume.Models.Mongo.DAO;
using static Plume.Models.Response.Post.UpdatePostLikeCountResponse;

namespace Plume.Service.Post
{
    public class PostService : IPostService
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IMapper _mapper;

        public PostService(IMongoRepository mongoRepository, IMapper mapper)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }

        public CreatePostResponse Create(CreatePostRequest request)
        {
            CreatePostResponse response = new CreatePostResponse();

            string postId = System.Guid.NewGuid().ToString();

            PostDAO postDAO = _mapper.Map<PostDAO>(request);
            postDAO.PostId = postId;
            postDAO.Timestamp = DateTime.Now;
            postDAO.LikeCount = 0;

            _mongoRepository.CreatePost(postDAO);

            response.PostId = postId;

            return response;
        }

        public GetPostByAccountIdResponse getByAccountId(GetPostByAccountIdRequest request)
        {
            GetPostByAccountIdResponse response = new GetPostByAccountIdResponse();

            response.Posts = _mongoRepository.FindPostByAccountId(request.AccountId).Result;

            return response;
        }

        public GetPostByPostIdResponse GetByPostId(GetPostByPostIdRequest request)
        {
            GetPostByPostIdResponse response = new GetPostByPostIdResponse();

            response.Post = _mongoRepository.FindPostByPostId(request.PostId).Result;

            return response;
        }

        public UpdatePostLikeCountResponse UpdatePostLikeCount(UpdatePostLikeCountRequest request)
        {
            UpdatePostLikeCountResponse response = new UpdatePostLikeCountResponse();

            ResponseStatus responseStatus = ResponseStatus.INTERNAL_ERROR;

            PostDAO postDAO = _mongoRepository.FindPostByAccountId(request.AccountId).Result.FirstOrDefault(post => post.PostId == request.PostId);
            if(postDAO != null)
            {
                int currentLikeCount = postDAO.LikeCount;
                if(currentLikeCount + request.LikeCountModification > -1)
                {
                    postDAO.LikeCount += request.LikeCountModification;

                    _mongoRepository.Update(postDAO);

                    responseStatus = ResponseStatus.SUCCESS;
                }
            }

            response.SetStatus(responseStatus);

            return response;
        }
    }
}
