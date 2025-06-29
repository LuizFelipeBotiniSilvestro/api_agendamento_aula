using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.Aula;

public class AulaDbContext : DbContext
{
    public AulaDbContext(DbContextOptions<AulaDbContext> options) : base(options) { }

    public DbSet<Aula> Aula => Set<Aula>();
}
