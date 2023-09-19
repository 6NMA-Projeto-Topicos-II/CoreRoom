using CoreRoom.Application.Mapper;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseBloquearSala : IUseCaseBloquearSala
    {
        private readonly IMongoRepository _repository;
        public UseCaseBloquearSala(IMongoRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> BlockRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);
            var ConsultandoSala = await _repository.Find(mapper);


            var
        }
    }
}
