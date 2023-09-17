using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Entities;

namespace CoreRoom.Ports.OutboundPort
{
    public interface IMongoRepository
    {
        public Task<EntityBlockAndRoomsMongoDB> Find(InputMongoRepository input);
        public Task Insert(EntityBlockAndRoomsMongoDB input);
        public Task<long> remove(InputMongoRepository input);

    }
}
