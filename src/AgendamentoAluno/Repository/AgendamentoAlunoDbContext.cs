using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoDbContext : DbContext
{
    public AgendamentoAlunoDbContext(DbContextOptions<AgendamentoAlunoDbContext> options) : base(options) { }

    public DbSet<AgendamentoAluno> AgendamentoAluno => Set<AgendamentoAluno>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgendamentoAluno>().ToTable("tb_agendamento_aluno", "agendamento");
    }
}
