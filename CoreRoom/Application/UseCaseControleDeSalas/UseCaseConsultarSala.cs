using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;
using System.Text.Json;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseConsultarSala : BaseUseCase, IUseCaseConsultarSala
    {
        public UseCaseConsultarSala(IMongoRepository repository) : base(repository)
        {
        }
        public async Task<string> FindByRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var ret = await _repository.FindRoom(mapper);
            if (ret == null)
                throw new BusinessException("Sala não Localizada");

            var response = MapperControleSalas.ForResponseConsultaSala(ret, input);

            var messageRet = JsonSerializer.Serialize(response);
            return messageRet;
        }
    }
}
