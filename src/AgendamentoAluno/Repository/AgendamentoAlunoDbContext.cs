using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoDbContext : DbContext
{
    public AgendamentoAlunoDbContext(DbContextOptions<AgendamentoAlunoDbContext> options) : base(options) { }

    public DbSet<AgendamentoAlunoEntity> AgendamentoAluno => Set<AgendamentoAlunoEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgendamentoAlunoEntity>().ToTable("tb_agendamento_aluno", "agendamento");

        // View para get
        modelBuilder.Entity<GetAgendamentoAlunoResult>().HasNoKey().ToView(null);
    }
}
