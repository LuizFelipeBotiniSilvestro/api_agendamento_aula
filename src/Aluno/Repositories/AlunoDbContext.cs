using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.Aluno;

public class AlunoDbContext : DbContext
{
    public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options) { }

    public DbSet<Aluno> Alunos => Set<Aluno>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().ToTable("tb_aluno", "cadastro");
    }
}