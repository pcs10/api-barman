using Barman.Data;
using Barman.Interfaces;
using Barman.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.

//precisa disso pra trabalhar com controladores
builder.Services.AddControllers();

//Banco de Dados
builder.Services.AddDbContext<AppDbContext>(
     opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

//interfaces e repositorios
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();

builder.Services.AddCors();


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
