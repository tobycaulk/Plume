using Plume.Models.Mongo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Mongo
{
    public interface IMongoRepository
    {
        //User account
        Task<IEnumerable<UserAccountDAO>> GetAllUserAccounts();
        Task<UserAccountDAO> CreateUserAccount(UserAccountDAO userAccountDAO);
        Task<UserAccountDAO> FindUserAccountByUsername(string username);
        Task<UserAccountDAO> FindUserAccountByAccountId(string accountId);

        //Post
        Task<IEnumerable<PostDAO>> GetAllPosts();
        Task<PostDAO> CreatePost(PostDAO postDAO);
        Task<PostDAO> FindPostByPostId(string postId);
        Task<IEnumerable<PostDAO>> FindPostByAccountId(string accountId);
        Task<PostDAO> Update(PostDAO postDAO);
    }
}
