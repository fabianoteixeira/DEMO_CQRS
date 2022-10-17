using DemoCQRS.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DemoCQRS.Read.Context
{
    public class ReadDbContext
    {
        private readonly MongoClient _mongoClient;
        public readonly IMongoDatabase _database;

        public ReadDbContext()
        {
            _mongoClient = new MongoClient("mongodb://10.0.0.100:27017");
            _database = _mongoClient.GetDatabase("DEMOCQRS");
            //Map();
        }

        public IMongoCollection<Person> People
        {
            get
            {
                return _database.GetCollection<Person>("People");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Person>(p => {
                p.MapIdProperty(p => p.Id);
            });
        }

    }
}
