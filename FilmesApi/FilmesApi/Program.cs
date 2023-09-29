//classe que define o que queremos fazer no momento da construção da aplicação

using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//variável para acessar o banco de dados
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

//Nós adicionamos uma conexão ao banco
builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySql(connectionString, ServerVersion
    .AutoDetect(connectionString)));

//Adicionar o automapper ao nosso projeto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adicionando o NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


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

