using CoreRoom.Adapters.MongoDBAdapter.Connections;
using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Entities;
using CoreRoom.Ports.OutboundPort;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoreRoom.Adapters.MongoDBAdapter.Repository
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoCollection<EntityBlockAndRoomsMongoDB> _Collection;
        public MongoRepository(IOptions<MongoSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<EntityBlockAndRoomsMongoDB>(
                settings.Value.CollectionName);
        }
        public async Task<EntityBlockAndRoomsMongoDB> Find(InputMongoRepository input) 
            => (await _Collection.FindAsync(x => x.Bloco == input.bloco)).FirstOrDefault();

        public async Task Insert(EntityBlockAndRoomsMongoDB input)
           => await _Collection.InsertOneAsync(input);
        
        public async Task<long> remove(InputMongoRepository input)
           =>( await _Collection.DeleteOneAsync(x => x.Bloco == input.bloco && x.id == input.id)).DeletedCount;

        public async Task UpdateBlockRoom(InputMongoRepository input)
        {
            var filtro = Builders<EntityBlockAndRoomsMongoDB>.Filter.And(
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq("_id", input.id),
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq("InfAndares.NumeroSala", input.numeroSala)
            );

            var atualizacao = Builders<EntityBlockAndRoomsMongoDB>.Update.Set("InfAndares.$.Bloqueada", input.Bloqueada);
            var ret = await _Collection.UpdateOneAsync(filter: filtro,update: atualizacao);
        }
    }
}
