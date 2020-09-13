using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongolab.Models
{
    public class Experiment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
        public List<ComponentUsed> ComponentUsed { get; set; }
        public string Procedure { get; set; }
    }

}
