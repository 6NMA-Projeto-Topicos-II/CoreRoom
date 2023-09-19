using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseBloquearSala
    {
        public Task<string> BlockRoom(inputControleSalas input);
    }
}
