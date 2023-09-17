using CoreRoom.Adapters.MongoDBAdapter.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreRoom.Infrastructure.Entensions
{
    public static class MongoDBExtensions
    {
        public static void AddMongoDB(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton(services.Configure<MongoSettings>(configuration.GetSection("MongoDBDatabase")));
        }
    }
}
