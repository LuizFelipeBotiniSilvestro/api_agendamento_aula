using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAula;

public class AgendamentoAulaDbContext : DbContext
{
    public AgendamentoAulaDbContext(DbContextOptions<AgendamentoAulaDbContext> options) : base(options) { }

    public DbSet<AgendamentoAula> AgendamentoAula => Set<AgendamentoAula>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgendamentoAula>().ToTable("tb_agendamento_aula", "agendamento");

        // Mapeamento para resultados customizados (DTOs)
        modelBuilder.Entity<GetAgendamentoAulaResult>().HasNoKey().ToView(null);
    }
}
