using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongolab.Models
{
    public class ComponentUsed
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double QuantityUsed { get; set; }
    }
}
