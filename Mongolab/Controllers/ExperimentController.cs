using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using Mongolab.Models;
namespace Mongolab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperimentController : ControllerBase
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<Experiment> _collection;
        public ExperimentController()
        {
            _client = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _client.GetDatabase("labRecord");
            _collection = _database.GetCollection<Experiment>("experiments");
        }
        [HttpGet]
        public object GetAllExperiments()
        {
            try
            {
                var experiments = _collection.Find(new BsonDocument());
                return Ok(experiments.ToJson());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public object InsertOrUpdate(Experiment expt) 
        {
            try
            {
                if (expt.id == null) {
                    _collection.InsertOne(expt);
                    return Ok();
                }
                else
                {
                    _collection.FindOneAndUpdateAsync(Builders<Experiment>.Filter.Eq("id", expt.id),
                                                        Builders<Experiment>.Update
                                                            .Set("Name", expt.Name)
                                                            .Set("Procedure", expt.Procedure)
                                                            .Set("StartDate", expt.StartDate)
                                                            .Set("ComponentUsed", expt.ComponentUsed));
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public object DeleteExperiment(Guid id)
        {
            try
            {
                _collection.DeleteOneAsync(Builders<Experiment>.Filter.Eq("id", id));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
       
}
