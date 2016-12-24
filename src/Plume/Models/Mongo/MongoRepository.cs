using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plume.Models.Mongo.DAO;
using Plume.Models.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Plume.Models.Mongo
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoContext _context = null;

        public MongoRepository(IOptions<MongoSettings> settings)
        {
            _context = new MongoContext(settings);
        }

        public async Task<IEnumerable<UserAccountDAO>> GetAllUserAccounts()
        {
            return await _context.UserAccountDAO.Find(_ => true).ToListAsync();
        }

        public async Task<UserAccountDAO> CreateUserAccount(UserAccountDAO userAccountDAO)
        {
            await _context.UserAccountDAO.InsertOneAsync(userAccountDAO);

            return await FindUserAccountByUsername(userAccountDAO.Username);
        }

        public async Task<UserAccountDAO> FindUserAccountByUsername(string username)
        {
            var filter = Builders<UserAccountDAO>.Filter.Eq("Username", username);
            return await _context.UserAccountDAO
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<UserAccountDAO> FindUserAccountByAccountId(string accountId)
        {
            var filter = Builders<UserAccountDAO>.Filter.Eq("AccountId", accountId);
            return await _context.UserAccountDAO
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PostDAO>> GetAllPosts()
        {
            return await _context.PostDAO.Find(_ => true).ToListAsync();
        }

        public async Task<PostDAO> CreatePost(PostDAO postDAO)
        {
            await _context.PostDAO.InsertOneAsync(postDAO);

            return await FindPostByPostId(postDAO.PostId);
        }

        public async Task<PostDAO> FindPostByPostId(string postId)
        {
            var filter = Builders<PostDAO>.Filter.Eq("PostId", postId);
            return await _context.PostDAO
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PostDAO>> FindPostByAccountId(string accountId)
        {
            return await _context.PostDAO.Find(post => post.AccountId == accountId).ToListAsync();
        }

        public async Task<PostDAO> Update(PostDAO postDAO)
        {
            var filter = Builders<PostDAO>.Filter.Eq("PostId", postDAO.PostId);
            await _context.PostDAO.ReplaceOneAsync(filter, postDAO);

            return await FindPostByPostId(postDAO.PostId);
        }
    }
}
