using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;
using System.Text.Json;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseConsultarSala : IUseCaseConsultarSala
    {
        private readonly IMongoRepository _repository;
        public UseCaseConsultarSala(IMongoRepository repository)
        {
            _repository = repository;
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
