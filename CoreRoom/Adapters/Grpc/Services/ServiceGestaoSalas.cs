using CoreRoom.Application.Mapper;
using CoreRoom.Domain;
using CoreRoom.Ports.InputboundPort;
using Grpc.Core;

namespace CoreRoom.Adapters.Grpc.Services
{
    public class ServiceGestaoSalas : GestaoSalasService.GestaoSalasServiceBase
    {

        private readonly IUseCaseAlocarSala _useCaseAlocar;
        private readonly IUseCaseConsultarSalaAlocada _useCaseConsultarSalaAlocada;
        private readonly IUseCaseDesalocarSala _useCaseDesalocar;
        private readonly IUseCaseListarSalasAlocada _useCaseListar;

        public ServiceGestaoSalas(IServiceProvider services)
        {
            _useCaseAlocar = services.GetRequiredService<IUseCaseAlocarSala>();
            _useCaseConsultarSalaAlocada = services.GetRequiredService<IUseCaseConsultarSalaAlocada>();
            _useCaseDesalocar = services.GetRequiredService<IUseCaseDesalocarSala>();
            _useCaseListar = services.GetRequiredService<IUseCaseListarSalasAlocada>();

        }

        public async override Task<BaseStatus> AlocarSala(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Bloco) || request.InfAndar.NumeroSala == 0 || request.InfAndar.Professor == null || request.InfAndar.Materia == null || request.InfAndar.Curso == null)
                    return BaseReturn("Obrigatório passar o Bloco, Número da sala, Professor e Materia", BaseStatus.Types.enumStatus.Negocio);

                var mapper = MapperControleSalas.ForUseCase(request);

                var usecaseRet = await _useCaseAlocar.UpdateAllocateRoom(mapper);



                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }
            catch (BusinessException ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Negocio);
            }
            catch (Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }
        
        public override async Task<BaseStatus> Desalocar(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Bloco) || request.InfAndar.NumeroSala == 0)
                    return BaseReturn("Obrigatorio passar Bloco e Numero da sala", BaseStatus.Types.enumStatus.Negocio);

                var mapper = MapperControleSalas.ForUseCase(request);

                var usecaseRet = await _useCaseDesalocar.DeallocateRoom(mapper);
                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }
            catch (BusinessException ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Negocio);
            }
            catch (Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }

        public override async Task<BaseStatus> ConsultarSalaAlocada(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Bloco) || request.InfAndar.NumeroSala == 0)
                    return BaseReturn("Obrigatorio passar Bloco e Numero da sala", BaseStatus.Types.enumStatus.Negocio);

                var mapper = MapperControleSalas.ForUseCase(request);

                var usecaseRet = await _useCaseConsultarSalaAlocada.FindByAllocateRoom(mapper);

                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }
            catch (BusinessException ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Negocio);
            }
            catch (Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }

        public async override Task<BaseStatus> ListarSalasAlocadas(BodyRequestSala request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Bloco))
                    return BaseReturn("Obrigatorio passar bloco", BaseStatus.Types.enumStatus.Negocio);
                
                var mapper = MapperControleSalas.ForUseCase(request);

                var usecaseRet = await _useCaseListar.ListAllocatedRoom(mapper);

                return BaseReturn(usecaseRet, BaseStatus.Types.enumStatus.Sucesso);
            }
            catch (BusinessException ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Negocio);
            }
            catch (Exception ex)
            {
                return BaseReturn(ex.Message, BaseStatus.Types.enumStatus.Sistema);
            }
        }

        public BaseStatus BaseReturn(string ret, BaseStatus.Types.enumStatus enumMessage)
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
