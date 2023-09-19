using CoreRoom.Application.Mapper;
using CoreRoom.Ports.InputboundPort;
using Grpc.Core;

namespace CoreRoom.Adapters.Grpc.Services
{
    public class ServiceControleSalas : ControleSalasService.ControleSalasServiceBase
    {
        private readonly IUseCaseConsultarSala _useCaseConsultar;
        public ServiceControleSalas(IServiceProvider services)
        {
            _useCaseConsultar = services.GetRequiredService<IUseCaseConsultarSala>();
        }

        public override Task<BaseStatus> CriarBloco(BodyRequestSala request, ServerCallContext context)
        {

            return base.CriarBloco(request, context); 
        }
        public override Task<BaseStatus> CriarSala(BodyRequestSala request, ServerCallContext context)
        {
            return base.CriarSala(request, context);
        }
        public async override Task<BaseStatus> ConsultarSala(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                var mapper = MapperControleSalas.ForUseCase(request);
                if(string.IsNullOrEmpty(mapper.Bloco) || request.InfAndar.NumeroSala == 0)
                    return BaseReturn("Obrigatorio passar Bloco e Numero da sala", BaseStatus.Types.enumStatus.Negocio);

                var usecaseRet = await _useCaseConsultar.FindByRoom(mapper);
                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }catch(Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }
        public async override Task<BaseStatus> BloquearSala(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                var mapper = MapperControleSalas.ForUseCase(request);
                if (string.IsNullOrEmpty(mapper.Bloco) || request.InfAndar.NumeroSala == 0)
                    return BaseReturn("Obrigatorio passar Bloco e Numero da sala", BaseStatus.Types.enumStatus.Negocio);

                var usecaseRet = await _useCaseConsultar.FindByRoom(mapper);
                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }
            catch (Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }
        public override Task<BaseStatus> DeletarSala(BodyRequestSala request, ServerCallContext context)
        {
            return base.DeletarSala(request, context);
        }
        public BaseStatus BaseReturn( string ret, BaseStatus.Types.enumStatus enumMessage)
        {
            return new BaseStatus
            {
                Status = enumMessage,
                DataResponse = DateTime.Now.ToString(),
                Message = ret
            };
        }
    }
}
