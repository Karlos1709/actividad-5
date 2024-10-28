using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Conexiones>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("conexiones") ?? throw new InvalidOperationException("Connection string 'conexiones' not found.")));

 
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ??"otracadena";
builder.Services.AddControllers();
builder.Services.AddDbContext<Conexiones>(opt =>
      opt.UseMySQL(cadena));

     
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
