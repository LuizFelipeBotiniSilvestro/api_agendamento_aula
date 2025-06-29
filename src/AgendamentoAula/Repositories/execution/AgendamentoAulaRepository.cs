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

    public async Task<bool> VerificarAgendamentoAulaExisteAsync(long id_agendamento_aula, CancellationToken cancellationToken)
    {
        return await _context.AgendamentoAula.AnyAsync(x => x.Id == id_agendamento_aula, cancellationToken);
    }

    public async Task<List<GetAgendamentoAulaResult>> GetAgendamentoAulaAsync(CancellationToken cancellationToken)
    {
        var sql = @"
                    SELECT 
                        aa.id,
                        aa.id_aula,
                        a.nm_aula,
                        aa.dt_aula
                    FROM agendamento.tb_agendamento_aula aa
                    INNER JOIN cadastro.tb_aula a ON a.id = aa.id_aula
                    ORDER BY aa.dt_aula
                ";

                return await _context
                    .Set<GetAgendamentoAulaResult>()
                    .FromSqlRaw(sql)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
    }
}
