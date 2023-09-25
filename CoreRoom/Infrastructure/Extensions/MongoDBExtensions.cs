using CoreRoom.Adapters.MongoDBAdapter.Connections;
using CoreRoom.Adapters.MongoDBAdapter.Repository;
using CoreRoom.Ports.OutboundPort;

namespace CoreRoom.Infrastructure.Entensions
{
    public static class MongoDBExtensions
    {
        public static void AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(services.Configure<MongoSettings>(configuration.GetSection("MongoDBDatabase")));
            services.AddScoped<IMongoRepository, MongoRepository>();
        }
    }
}
