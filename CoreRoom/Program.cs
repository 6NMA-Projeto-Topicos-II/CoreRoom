using CoreRoom.Adapters.Grpc.Services;
using CoreRoom.Infrastructure.Entensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddMongoDB(builder.Configuration);
builder.Services.AddDomainExtensions();
var app = builder.Build();

app.MapGrpcService<ServiceControleSalas>();


app.Run();
