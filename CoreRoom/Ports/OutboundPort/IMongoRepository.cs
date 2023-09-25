using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Entities;

namespace CoreRoom.Ports.OutboundPort
{
    public interface IMongoRepository
    {
        public Task<EntityBlockAndRoomsMongoDB> FindBlock(InputMongoRepository input);
        public Task<EntityBlockAndRoomsMongoDB> FindRoom(InputMongoRepository input);
        public Task<string> UpdateBlockRoom(InputMongoRepository input);
        public Task Insert(EntityBlockAndRoomsMongoDB input);
        public Task<long> remove(InputMongoRepository input);
        public Task<string> UpdateBlock(EntityBlockAndRoomsMongoDB input);

    }
}
