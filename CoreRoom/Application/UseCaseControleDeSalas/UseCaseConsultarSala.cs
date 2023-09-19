using CoreRoom.Application.Mapper;
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
            var ret = await _repository.Find(mapper);
            var response = ret.InfAndares.Select(x => x.NumeroSala = input.Infsala.NumeroSala).FirstOrDefault();
            var messageRet = JsonSerializer.Serialize(response);
            return messageRet;
        }
    }
}
