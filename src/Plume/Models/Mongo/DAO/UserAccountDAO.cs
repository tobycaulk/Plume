using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Mongo.DAO
{
    public class UserAccountDAO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string AccountId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> LikedPosts { get; set; }
    }
}
