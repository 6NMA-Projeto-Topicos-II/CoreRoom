using CoreRoom.Ports.InputboundPort.InputGestaoSalas;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseGestaoDeSalas
{
    public class UseCaseAlocarSala : IUseCaseAlocarSala
    {
        private readonly IMongoRepository _repository;

        public UseCaseAlocarSala(IMongoRepository repository)
        {
            _repository = repository;
        }


    }
}
