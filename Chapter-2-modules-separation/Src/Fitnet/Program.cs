using EvolutionaryArchitecture.Fitnet.Common.Api.Documentation;
using EvolutionaryArchitecture.Fitnet.Common.Api.ErrorHandling;
using EvolutionaryArchitecture.Fitnet.Common.Infrastructure;
using EvolutionaryArchitecture.Fitnet.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandling();
builder.Services.AddCommonInfrastructure();
builder.Services.AddModules(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseErrorHandling();
app.MapControllers();

app.RegisterModules();

await app.RunAsync();


namespace EvolutionaryArchitecture.Fitnet
{
    [UsedImplicitly]
    public sealed class Program;
}
