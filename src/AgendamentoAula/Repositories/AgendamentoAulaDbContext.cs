using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAula;

public class AgendamentoAulaDbContext : DbContext
{
    public AgendamentoAulaDbContext(DbContextOptions<AgendamentoAulaDbContext> options): base(options)
    {
    }

    public DbSet<AgendamentoAula> agendamentoAula => Set<AgendamentoAula>();
}
