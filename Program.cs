using API_Cursos.Data;
using API_Cursos.Interfaces;
using API_Cursos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EscuelaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscuelaConnection")));

//SERVICIOS
builder.Services.AddScoped<IAlumnosService, AlumnosService>();
builder.Services.AddScoped<IProfesoresService, ProfesoresService>();
builder.Services.AddScoped<ICursosService, CursosService>();
builder.Services.AddScoped<IInscripcionesService, InscripcionesService>();

//HTTPCLIENT
builder.Services.AddHttpClient();

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
