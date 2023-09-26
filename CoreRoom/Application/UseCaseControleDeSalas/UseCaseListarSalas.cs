using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseListarSalas : BaseUseCase, IUseCaseListarSalas
    {
        public UseCaseListarSalas(IMongoRepository repository) : base(repository)
        {
        }

        public Task<string> ListRoom(inputControleSalas input)
        {
            throw new NotImplementedException();
        }
    }
}
