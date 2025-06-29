using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAula;

public class AgendamentoAulaRepository : IAgendamentoAulaRepository
{
    private readonly AgendamentoAulaDbContext _context;

    public AgendamentoAulaRepository(AgendamentoAulaDbContext context)
    {
        _context = context;
    }

    public async Task<AgendamentoAula> CriarAsync(AgendamentoAula agendamento, CancellationToken cancellationToken)
    {
        await _context.AgendamentoAula.AddAsync(agendamento, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await _context.Entry(agendamento).ReloadAsync(cancellationToken);
        return agendamento;
    }
}
