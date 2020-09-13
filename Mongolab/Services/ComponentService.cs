using MongoDB.Driver;
using MongoDB.Bson;
using Mongolab.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Mongolab.Services
{
    public class ComponentService
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<Component> _collection;

        public ComponentService()
        {
            _client = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _client.GetDatabase("labRecord");
            _collection = _database.GetCollection<Component>("components");
        }

        public List<Component> Get()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }
        public Component Get(string id)
        {
            return _collection.Find<Component>(cmpt => cmpt.Id == id).FirstOrDefault();
        }
        public Component Insert(Component cmpt)
        {
            _collection.InsertOne(cmpt);
            return (cmpt);
        }
        public void Delete(string id)
        {
            _collection.DeleteOneAsync(Builders<Component>.Filter.Eq("Id", id));
        }
    }

}