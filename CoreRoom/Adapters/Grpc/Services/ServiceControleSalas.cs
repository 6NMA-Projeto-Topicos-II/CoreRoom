using CoreRoom.Application.Mapper;
using Grpc.Core;
using System.Text.Json;

namespace CoreRoom.Adapters.Grpc.Services
{
    public class ServiceControleSalas : ControleSalasService.ControleSalasServiceBase
    {

        public override Task<BaseStatus> CriarBloco(RequestControleSalas request, ServerCallContext context)
        {

            return base.CriarBloco(request, context); 
        }
        public override Task<BaseStatus> CriarSala(RequestControleSalas request, ServerCallContext context)
        {
            return base.CriarSala(request, context);
        }
        public override Task<BaseStatus> ConsultarSala(RequestControleSalas request, ServerCallContext context)
        {
            var mapper = MapperControleSalas.ForUseCase(request);
            return base.ConsultarSala(request, context);
        }
        public override Task<BaseStatus> BloquearSala(RequestControleSalas request, ServerCallContext context)
        {
            return base.BloquearSala(request, context);
        }
        public override Task<BaseStatus> DeletarSala(RequestControleSalas request, ServerCallContext context)
        {
            return base.DeletarSala(request, context);
        }
    }
}
