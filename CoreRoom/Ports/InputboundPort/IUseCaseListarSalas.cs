using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseListarSalas
    {
        public Task<string> ListRoom(inputControleSalas input);
    }
}
