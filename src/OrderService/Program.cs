using MassTransit;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddMassTransit(x =>
{

})


app.Run();
