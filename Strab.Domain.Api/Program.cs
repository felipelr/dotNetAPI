using Strab.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Repositories;
using Strab.Domain.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(5, 7, 32));
var connectiontring = builder.Configuration.GetConnectionString("mysqlConnection");
builder.Services.AddDbContext<StrabContext>(options => options.UseMySql(connectiontring, serverVersion));

//dependencias dos repositorios
builder.Services.AddTransient<IUserRepository, UserRepository>();

//dependencias dos handlers

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
