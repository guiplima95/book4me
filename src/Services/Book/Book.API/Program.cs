using System.Net;
using Book.API;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Configure gRPC:
// builder.WebHost.ConfigureKestrel(options =>
// {
//     int grpcPort = builder.Configuration.GetValue("GRPC_PORT", 5900);
//     int httpPort = builder.Configuration.GetValue("PORT", 5901);

//     options.Listen(IPAddress.Any, httpPort, listenOptions => listenOptions.Protocols = HttpProtocols.Http1AndHttp2);
//     options.Listen(IPAddress.Any, grpcPort, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
// });

builder.AddSwagger();
builder.AddCustomDbContext(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerApi();
}

app.UseHttpsRedirection();

app.MapBookApi();

app.Run();