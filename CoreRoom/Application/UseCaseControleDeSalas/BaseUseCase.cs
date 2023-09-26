using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public abstract class BaseUseCase
    {
        protected  IMongoRepository _repository;
        public BaseUseCase(IMongoRepository repository)
        {
            _repository = repository;
        }
    }
}
