using MasterEventos.Persistence;
using MasterEventos.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Essa é a configuração para pegar a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Default");

//Criamos o contexto e adicionamos a string de comnexão no dbContext
builder.Services.AddDbContext<MasterEventosContext>(
    context => context.UseSqlite(connectionString)
);

builder.Services.AddControllers();
builder.Services.AddCors(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseAuthorization();

app.UseCors(cors => cors.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

app.MapControllers();

app.Run();
