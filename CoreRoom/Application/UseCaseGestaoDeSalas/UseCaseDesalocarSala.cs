using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseGestaoDeSalas
{
    public class UseCaseDesalocarSala : IUseCaseDesalocarSala
    {

        private readonly IMongoRepository _repository;

        public UseCaseDesalocarSala(IMongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> DeallocateRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var ConsultandoSala = await _repository.FindRoom(mapper);

            if (ConsultandoSala == null)
                throw new BusinessException("Sala não localizada");

            mapper.id = ConsultandoSala.id;

            var ret = await _repository.UpdateDeallocateRoom(mapper);
            return ret;
        }

    }
}
