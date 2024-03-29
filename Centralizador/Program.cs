using Centralizador.Repositorios;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Centralizador.ComunicacionSync.http.ClienteHttp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson( s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UniversidadDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("una_conexion")));
builder.Services.AddScoped<IEstudianteRepository, ImplEstudianteRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICampusHistorialCliente, ImplCampusHistorialCliente>();

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
