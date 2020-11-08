using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MovieQueueBackend.Models
{
    public class QueueItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        // can be a movie or tv show
        public string Type { get; set; }

        public string Seasons {get; set;}

        public string User {get; set;}

        public string Created { get; set; }
    }
}
