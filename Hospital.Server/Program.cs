using Hospital.Server.Context;
using Hospital.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Hospital.Server.IRepository;
using Hospital.Server.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configura��o de Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:5173") // URL front-end
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configura��o de Swagger (Documenta��o da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do Entity Framework com SQL Server
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar servi�os (Service Layer)
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<ITriagemService, TriagemService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();

// Adicionar reposit�rios (Repository Layer)
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<ITriagemRepository, TriagemRepository>();
builder.Services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

// Configura��o do app
var app = builder.Build();

// Configura��o de arquivos est�ticos
app.UseDefaultFiles();
app.UseStaticFiles();

// Use CORS
app.UseCors("AllowSpecificOrigin");

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // Swagger para desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionamento HTTPS
app.UseHttpsRedirection();

// Middleware de Autoriza��o
app.UseAuthorization();

// Mapeamento de Controllers
app.MapControllers();

// Configura��o para fallback (SPA)
app.MapFallbackToFile("/index.html");

app.Run();














//using Hospital.Server.Context;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//app.Run();

