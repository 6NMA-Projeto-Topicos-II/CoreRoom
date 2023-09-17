using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Ports.InputboundPort
{
    public interface IUseCaseConsultarSala
    {
        public Task<string> FindByRoom(inputControleSalas input);
    }
}
