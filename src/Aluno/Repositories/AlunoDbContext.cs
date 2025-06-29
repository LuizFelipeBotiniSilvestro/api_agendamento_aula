using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.Aluno;

public class AlunoDbContext : DbContext
{
    public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }
}
