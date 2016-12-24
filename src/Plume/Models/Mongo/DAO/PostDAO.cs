using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Mongo.DAO
{
    public class PostDAO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string AccountId { get; set; }
        public string PostId { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
