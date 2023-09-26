using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseCriarBloco : BaseUseCase, IUseCaseCriarBloco
    {
        public UseCaseCriarBloco(IMongoRepository repository) : base(repository)
        {
        }

        public Task<string> NewBlock(inputControleSalas input)
        {
            throw new NotImplementedException();
        }
    }
}
