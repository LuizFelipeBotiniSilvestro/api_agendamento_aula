namespace SistemaAgendamento.Aula;

public class AulaRepository : IAulaRepository
{
    private readonly AulaDbContext _context;

    public AulaRepository(AulaDbContext context)
    {
        _context = context;
    }

    public async Task<Aula> CriarAsync(Aula aula, CancellationToken cancellationToken)
    {
        await _context.Aula.AddAsync(aula, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // Atualiza os campos gerados automaticamente, como dt_inc
        await _context.Entry(aula).ReloadAsync(cancellationToken);
        
        return aula;
    }
}
