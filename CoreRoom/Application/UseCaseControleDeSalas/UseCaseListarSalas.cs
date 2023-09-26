using CoreRoom.Application.Mapper;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;
using System.Text.Json;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseListarSalas : BaseUseCase, IUseCaseListarSalas
    {
        public UseCaseListarSalas(IMongoRepository repository) : base(repository)
        {
        }

        public async Task<string> ListRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var ret = await _repository.FindBlock(mapper);

            var listaRetorno = new List<ResponseConsultaSalasControle>();

            ret.InfAndares.ToList().ForEach(x =>
            {
                var RetMapSala = new ResponseConsultaSalasControle
                {
                    bloco = ret.Bloco,
                    Bloqueada = x.Bloqueada,
                    capacidadeDeAlunos = x.CapacidadeDeAlunos,
                    EmAula = x.Ativa,
                    NumeroDaSala = x.NumeroSala,
                    numeroDoAndar = x.Andar,
                };
                listaRetorno.Add(RetMapSala);
            });

            var listaSerializada = JsonSerializer.Serialize(listaRetorno);

            return listaSerializada;
        }
    }
}
