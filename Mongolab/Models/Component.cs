using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Mongolab.Models
{
    public class Component
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double QuantityLeft { get; set; }
        public string Dealer { get; set; }

    }

}
