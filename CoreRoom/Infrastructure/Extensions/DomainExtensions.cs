using CoreRoom.Application.UseCaseControleDeSalas;
using CoreRoom.Ports.InputboundPort;

namespace CoreRoom.Infrastructure.Entensions
{
    public static class DomainExtensions
    {
         public static void AddDomainExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseConsultarSala, UseCaseConsultarSala>();
            services.AddScoped<IUseCaseBloquearSala, UseCaseBloquearSala>();
            services.AddScoped<IUseCaseCriarSala, UseCaseCriarSala>();
        }
    }
}
