using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plume.Models.Mongo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Mongo
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<MongoSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            if(client != null)
            {
                _database = client.GetDatabase(mongoSettings.Value.Database);
            }
        }

        public IMongoCollection<UserAccountDAO> UserAccountDAO
        {
            get
            {
                return _database.GetCollection<UserAccountDAO>("userAccount");
            }
        }

        public IMongoCollection<PostDAO> PostDAO
        {
            get
            {
                return _database.GetCollection<PostDAO>("post");
            }
        }
    }
}
