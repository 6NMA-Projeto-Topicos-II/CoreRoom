using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseCriarBloco
    {
        public Task<string> NewBlock(inputControleSalas input);
    }
}
