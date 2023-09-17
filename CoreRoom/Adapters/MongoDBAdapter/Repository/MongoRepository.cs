using CoreRoom.Adapters.MongoDBAdapter.Connections;
using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Entities;
using CoreRoom.Ports.OutboundPort;
using Microsoft.Extensions.Options;
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
        {
            try
            {

                var ret = await _Collection.FindAsync(x => x.Bloco == input.bloco );
                return ret.FirstOrDefault();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task Insert(EntityBlockAndRoomsMongoDB input)
        {
            await _Collection.InsertOneAsync(input);
        }

        public async Task<long> remove(InputMongoRepository input)
        {
            var ret = await _Collection.DeleteOneAsync(x => x.Bloco == input.bloco && x.id == input.id);

            return ret.DeletedCount;
        }

    }
}
