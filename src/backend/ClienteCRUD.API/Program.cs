using ClienteCRUD.API.Converters;
using ClienteCRUD.API.Filtros;
using ClienteCRUD.Application;
using ClienteCRUD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter())); // esse AddJsonOptions serve para adicionar o nosso conversor de string
builder.Services.AddEndpointsApiExplorer();                                                                                       // que foi criado na pasta Converters, que serve para remover os espaços
builder.Services.AddSwaggerGen();                                                                                                 // em branco extras de uma string e
                                                                                                                                  // deixar como padrão um espaço em branco entre uma palavra,
                                                                                                                                  // por exemplo: "Vinicius Colazelli" tem um espaço entre o nome e sobrenome

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
