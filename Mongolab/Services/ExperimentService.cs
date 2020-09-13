using MongoDB.Driver;
using MongoDB.Bson;
using Mongolab.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Mongolab.Services
{
    public class ExperimentService
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Experiment> _collection;

        public ExperimentService()
        {
            this._client = new MongoClient("mongodb://127.0.0.1:27017");
            this._database = this._client.GetDatabase("labRecord");
            this._collection = this._database.GetCollection<Experiment>("experiments");
        }

        public List<Experiment> Get()
        {
            return this._collection.Find(new BsonDocument()).ToList();
        }
        public Experiment Get(string id)
        {
            return _collection.Find<Experiment>(expt => expt.Id == id).FirstOrDefault();
        }
        public Experiment Insert(Experiment expt)
        {
            this._collection.InsertOne(expt);
            return (expt);
        }
        public void Delete(string id)
        {
            this._collection.DeleteOneAsync(Builders<Experiment>.Filter.Eq("Id", id));
        }


    }

}