using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Dto.ControleSalasDto;
using CoreRoom.Domain.Entities;

namespace CoreRoom.Application.Mapper
{
    public static class MapperControleSalas
    {
        public static inputControleSalas ForUseCase(BodyRequestSala requestControleSalas)
        {
            return new inputControleSalas
            {
                Bloco = requestControleSalas.Bloco ?? "" ,
                NumeroAndares = requestControleSalas.NumeroDeAndares,
                NumeroDeSalas = requestControleSalas.NumeroDeSalas,
                Infsala = new InfAndares
                {
                    NumeroDoAndar = requestControleSalas.InfAndar.NumeroDoAndar,
                    NumeroSala = requestControleSalas.InfAndar.NumeroSala,
                    Auditorio = requestControleSalas.InfAndar.Auditorio,
                    laboratorio = requestControleSalas.InfAndar.Laboratorio,
                    capacidadeDeAlunos = requestControleSalas.InfAndar.CapacidadeDeAlunos
                }

            };
        }
        public static InputMongoRepository ForRepository(inputControleSalas input)
        {
            return new InputMongoRepository
            {
                bloco = input.Bloco,
                NumeroAndares = input.NumeroAndares,
                NumeroDeSalas = input.NumeroDeSalas,
                NumeroDoAndar = input.Infsala.NumeroDoAndar,
                numeroSala = input.Infsala.NumeroSala,
                laboratorio = input.Infsala.laboratorio,
                Auditorio = input.Infsala.laboratorio,
                capacidadeDeAlunos = input.Infsala.capacidadeDeAlunos
            };
        }
        public static ResponseConsultaSalasControle ForResponseConsultaSala(EntityBlockAndRoomsMongoDB ResponseMongo, inputControleSalas inputControle)
        {
            return new ResponseConsultaSalasControle
            {
                bloco = ResponseMongo.Bloco,
                numeroDoAndar = ResponseMongo.InfAndares.ToList().Where(x => x.NumeroSala == inputControle.Infsala.NumeroSala).Select(x => x.Andar).First(),
                Bloqueada = ResponseMongo.InfAndares.ToList().Where(x => x.NumeroSala == inputControle.Infsala.NumeroSala).Select(x => x.Bloqueada).First(),
                capacidadeDeAlunos = ResponseMongo.InfAndares.ToList().Where(x => x.NumeroSala == inputControle.Infsala.NumeroSala).Select(x => x.CapacidadeDeAlunos).First(),
                EmAula = ResponseMongo.InfAndares.ToList().Where(x => x.NumeroSala == inputControle.Infsala.NumeroSala).Select(x => x.Ativa).First(),
                NumeroDaSala = ResponseMongo.InfAndares.ToList().Where(x => x.NumeroSala == inputControle.Infsala.NumeroSala).Select(x => x.NumeroSala).First(),

            };
        }
    }
}
