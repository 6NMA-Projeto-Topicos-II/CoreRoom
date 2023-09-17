using CoreRoom.Adapters.Grpc.Services;
using CoreRoom.Infrastructure.Entensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddMongoDB(builder.Configuration);

var app = builder.Build();

app.MapGrpcService<ServiceControleSalas>();


app.Run();
