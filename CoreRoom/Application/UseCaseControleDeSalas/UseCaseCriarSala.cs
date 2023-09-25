using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Domain.Entities;
using CoreRoom.Ports.InputboundPort;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Application.UseCaseControleDeSalas
{
    public class UseCaseCriarSala : IUseCaseCriarSala
    {
        private readonly IMongoRepository _repository;
        public UseCaseCriarSala(IMongoRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> NewRoom(inputControleSalas input)
        {
            var mapper = MapperControleSalas.ForRepository(input);

            var findblock = await _repository.FindBlock(mapper);

            findblock.InfAndares.ToList().ForEach(x =>
            {
                if (x.NumeroSala == input.Infsala.NumeroSala)
                    throw new BusinessException("Sala já Existente");
            });

            findblock.InfAndares.Add(new Domain.Entities.Floorinformation
            {
                Andar = input.Infsala.NumeroDoAndar,
                CapacidadeDeAlunos = input.Infsala.capacidadeDeAlunos,
                Auditorio = input.Infsala.Auditorio,
                Ativa = false,
                Bloqueada = false,
                Curso = "",
                DataHoraFim = new DateTime(1900,01,01,00,00,00),
                DataHoraInicio = new DateTime(1900, 01, 01, 00, 00, 00),
                Laboratorio = input.Infsala.laboratorio,
                Materia = "",
                NumeroSala = input.Infsala.NumeroSala,
                Professor = ""
            });

            findblock.InfAndares = OrganizaListaDeSalas(findblock.InfAndares);

            var ret = await _repository.UpdateBlock(findblock);

            return ret;
        }

        public IList<Floorinformation> OrganizaListaDeSalas(IList<Floorinformation> listaAntiga)
        {
            var novaLista = new List<Floorinformation>();

            while(listaAntiga.Count != 0)
            {
                var menorNumeroSala = listaAntiga.Select(x => x.NumeroSala).Min();

                var menorObjeto = listaAntiga.Where(x => x.NumeroSala == menorNumeroSala).First();

                novaLista.Add(menorObjeto);

                listaAntiga.Remove(menorObjeto);

            }

            return novaLista;
        }

    }
}
