using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Domain.Entities;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseCriarBloco : BaseUseCase, IUseCaseCriarBloco
    {
        public UseCaseCriarBloco(IMongoRepository repository) : base(repository)
        {
        }

        public async  Task<string> NewBlock(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var consulta = await _repository.FindBlock(mapper);

            if (consulta != null)
                throw new BusinessException("Bloco Já Existente");

            var Bloco = new EntityBlockAndRoomsMongoDB
            {
                Bloco = input.Bloco,
                TotalDeAndares = input.NumeroAndares,
                TotalDeSalas = input.NumeroDeSalas,
                Responsavel = "",
                InfAndares = new List<Floorinformation>()
            };

             await _repository.Insert(Bloco);

            return "Bloco Criado com Sucesso";
        }
    }
}
