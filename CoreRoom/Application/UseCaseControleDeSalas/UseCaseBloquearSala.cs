using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseBloquearSala : BaseUseCase, IUseCaseBloquearSala
    {
        public UseCaseBloquearSala(IMongoRepository repository) : base(repository)
        {
        }
        public async Task<string> BlockRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var ConsultandoSala = await _repository.FindRoom(mapper);
            if (ConsultandoSala == null)
                throw new BusinessException("Sala não Localizada");
            
            mapper.id = ConsultandoSala.id;
            
            var ret = await _repository.UpdateBlockRoom(mapper);
            return ret;
        }
    }
}
