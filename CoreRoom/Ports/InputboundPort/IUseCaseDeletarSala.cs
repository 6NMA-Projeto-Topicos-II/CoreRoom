using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseDeletarSala
    {
        public Task<string> DeleteRoom(inputControleSalas input);
    }
}
