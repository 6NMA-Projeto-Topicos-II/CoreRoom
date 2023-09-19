using CoreRoom.Domain.Dto;
using CoreRoom.Domain.Dto.ControleSalasDto;

namespace CoreRoom.Application.Mapper
{
    public static class MapperControleSalas
    {
        public static inputControleSalas ForUseCase(BodyRequestSala requestControleSalas)
        {
            return new inputControleSalas
            {
                Bloco =char.Parse( requestControleSalas.Bloco),
                NumeroAndares= requestControleSalas.,

            };
        }
        public static InputMongoRepository ForRepository(inputControleSalas input)
        {
            return new InputMongoRepository
            {
                bloco = char.Parse(input.Bloco)
            };
        }
    }
}
