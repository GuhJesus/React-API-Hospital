using Hospital.Server.Context;
using Hospital.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Hospital.Server.IRepository;
using Hospital.Server.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração de Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:5173") // URL front-end
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configuração de Swagger (Documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do Entity Framework com SQL Server
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar serviços (Service Layer)
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<ITriagemService, TriagemService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();

// Adicionar repositórios (Repository Layer)
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<ITriagemRepository, TriagemRepository>();
builder.Services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

// Configuração do app
var app = builder.Build();

// Configuração de arquivos estáticos
app.UseDefaultFiles();
app.UseStaticFiles();

// Use CORS
app.UseCors("AllowSpecificOrigin");

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // Swagger para desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionamento HTTPS
app.UseHttpsRedirection();

// Middleware de Autorização
app.UseAuthorization();

// Mapeamento de Controllers
app.MapControllers();

// Configuração para fallback (SPA)
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

