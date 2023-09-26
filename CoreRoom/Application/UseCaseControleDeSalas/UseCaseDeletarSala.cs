using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseDeletarSala : IUseCaseDeletarSala
    {
        private readonly IMongoRepository _repository;
        public UseCaseDeletarSala(IMongoRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> DeleteRoom(inputControleSalas input)
        {
            try
            {
                var mapper = MapperControleSalas.ForRepository(input);

                var findblock = await _repository.FindBlock(mapper);
                var sala = findblock.InfAndares.Where(x => x.NumeroSala == input.Infsala.NumeroSala).First();

                if (sala.NumeroSala == input.Infsala.NumeroSala && sala.Ativa == true)
                    throw new BusinessException("Sala não pode ser Excluida. Em funcionamento");

                findblock.InfAndares.Remove(sala);

                var ret = await _repository.UpdateBlock(findblock);

                return ret;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessException("Sala não encontrada");
            }

        }
    }
}
