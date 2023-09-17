using CoreRoom.Domain.Entities;

namespace CoreRoom.Ports.OutboundPort
{
    public interface IMongoRepository
    {
        public Task<EntityBlockAndRoomsMongoDB> Find()
    }
}
