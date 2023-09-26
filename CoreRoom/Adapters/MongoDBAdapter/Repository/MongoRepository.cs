using CoreRoom.Adapters.MongoDBAdapter.Connections;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Entities;
using CoreRoom.Ports.OutboundPort;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

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
        public async Task<EntityBlockAndRoomsMongoDB> FindBlock(InputMongoRepository input) 
            => (await _Collection.FindAsync(x => x.Bloco == input.bloco)).FirstOrDefault();

        public async  Task<EntityBlockAndRoomsMongoDB> FindRoom(InputMongoRepository input)
        {
            var filtro = Builders<EntityBlockAndRoomsMongoDB>.Filter.And(
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq(x => x.Bloco , input.bloco),
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq("InfAndares.NumeroSala", input.numeroSala)
            );
            var ret = await _Collection.FindAsync(filtro);
            return ret.FirstOrDefault();
        }

        public async Task Insert(EntityBlockAndRoomsMongoDB input)
           => await _Collection.InsertOneAsync(input);
        
        public async Task<long> remove(InputMongoRepository input)
           =>( await _Collection.DeleteOneAsync(x => x.Bloco == input.bloco && x.id == input.id)).DeletedCount;

        public async Task<string> UpdateBlockRoom(InputMongoRepository input)
        {
            var filtro = Builders<EntityBlockAndRoomsMongoDB>.Filter.And(
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq(x => x.id, input.id),
                Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq("InfAndares.NumeroSala", input.numeroSala)
            );

            var atualizacao = Builders<EntityBlockAndRoomsMongoDB>.Update.Set("InfAndares.$.Bloqueada", input.Bloqueada);
            var ret = await _Collection.UpdateOneAsync(filter: filtro,update: atualizacao);

            if (ret.ModifiedCount == 0)
                throw new BusinessException("Erro ao Alterar Bloqueio de sala");

            return "Bloqueio atualizado com sucesso";
        }
        public async Task<string> UpdateBlock(EntityBlockAndRoomsMongoDB input)
        {
            var filtro = Builders<EntityBlockAndRoomsMongoDB>.Filter.Eq(x => x.id, input.id);

            var atualizacao = Builders<EntityBlockAndRoomsMongoDB>.Update.Set("InfAndares", input.InfAndares);
            var ret = await _Collection.UpdateOneAsync(filter: filtro, update: atualizacao);

            if (ret.ModifiedCount == 0)
                throw new BusinessException("Erro ao Atualizar bloco");

            return "Sucesso";
        }

    }
}
