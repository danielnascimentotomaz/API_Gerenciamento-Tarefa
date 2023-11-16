using GerenciamentoTarefa.Controllers;
using GerenciamentoTarefa.Database;
using GerenciamentoTarefa.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var serverVersion = new MySqlServerVersion(new Version(8,2,0));
var stringConexao = builder.Configuration.GetConnectionString("conexaoPadrao");
    
builder.Services.AddDbContext<TarefaContext>(options => options.UseMySql(stringConexao, serverVersion));



/*
Um serviço transitório significa que uma nova instância do serviço será criada toda vez que ele for solicitado. Isso é útil para serviços leves que não têm estado duradouro. Cada vez que você injetar TarefaService em uma classe, uma nova instância dele será fornecida.
*/
builder.Services.AddTransient<TarefaImplService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







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
