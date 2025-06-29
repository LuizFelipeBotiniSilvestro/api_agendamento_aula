using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Aluno;
using SistemaAgendamento.Aula;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Serviços e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 💾 DbContext (PostgreSQL)
builder.Services.AddDbContext<AlunoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("db")));
builder.Services.AddDbContext<AulaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("db")));

// 💡 Injeção de dependência 

// Módulo Aluno
builder.Services.AddScoped<ICreateAlunoUseCase, CreateAlunoUseCase>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
// Módulo Aula
builder.Services.AddScoped<ICreateAulaUseCase, CreateAulaUseCase>();
builder.Services.AddScoped<IAulaRepository, AulaRepository>();


var app = builder.Build();

// 📜 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Mostra mensagem quando a aplicação já estiver realmente rodando
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    if (app.Environment.IsDevelopment())
    {
        Console.WriteLine();
        Console.WriteLine("✅ API em execução no ambiente de desenvolvimento");
        Console.WriteLine("🔗 Swagger: http://localhost:5045/swagger");
        Console.WriteLine();
    }
});

app.Run();
