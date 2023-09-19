using Grpc.Core;

namespace CoreRoom.Adapters.Grpc.Services
{
    public class ServiceGestaoSalas : GestaoSalasService.GestaoSalasServiceBase
    {
        public override Task<BaseStatus> AlocarSala(BodyRequestSala request, ServerCallContext context)
        {
            return base.AlocarSala(request, context);
        }


        public override Task<BaseStatus> ConsultarSala(BodyRequestSala request, ServerCallContext context)
        {
            return base.ConsultarSala(request, context);
        }
        public override Task<BaseStatus> ConsultarSalaAlocada(BodyRequestSala request, ServerCallContext context)
        {
            return base.ConsultarSalaAlocada(request, context);
        }

        public override Task<BaseStatus> Desalocar(BodyRequestSala request, ServerCallContext context)
        {
            return base.Desalocar(request, context);
        }

        public override Task<BaseStatus> ListarSalaAlocada(BodyRequestSala request, ServerCallContext context)
        {
            return base.ListarSalaAlocada(request, context);
        }

    }
}
