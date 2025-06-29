using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.Aula;

public class AulaDbContext : DbContext
{
    public AulaDbContext(DbContextOptions<AulaDbContext> options) : base(options) { }

    public DbSet<Aula> Aula => Set<Aula>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aula>().ToTable("tb_aula", "cadastro");
    }
}
