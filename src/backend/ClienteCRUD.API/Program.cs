using ClienteCRUD.API.Filtros;
using ClienteCRUD.Application;
using ClienteCRUD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(opcao => opcao.Filters.Add(typeof(FiltroException))); // esse builder serve para que nossa API entenda que essa classe 'FiltroException' seja utilizada como um filtro de Exceção

builder.Services.AddInfrastructure(builder.Configuration); // esses dois servem para adicionar as injeções de dependencia de infraestrutura e application.
builder.Services.AddApplication();                    // Esse parametro builder.Configuration é para pegar as configurações do appsettings.Development.json, no caso a connection string do banco de dados.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
