using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseCriarSala
    {
        public Task<string> NewRoom(inputControleSalas input);
    }
}
