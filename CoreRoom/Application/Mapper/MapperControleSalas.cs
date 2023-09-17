using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Application.Mapper
{
    public static class MapperControleSalas
    {
        public static inputControleSalas ForUseCase(RequestControleSalas requestControleSalas)
        {
            return new inputControleSalas
            {
                Bloco = requestControleSalas.Bloco,
                Sala = requestControleSalas.NumeroSala
            };
        }
        public static InputMongoRepository ForRepository(inputControleSalas input)
        {
            return new InputMongoRepository
            {
                bloco = input.Bloco
            };
        }
    }
}
