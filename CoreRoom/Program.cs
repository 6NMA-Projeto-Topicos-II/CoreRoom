using CoreRoom.Infrastructure.Entensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddMongoDB(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();


app.Run();
