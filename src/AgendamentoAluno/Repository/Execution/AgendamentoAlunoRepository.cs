using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoRepository : IAgendamentoAlunoRepository
{
    private readonly AgendamentoAlunoDbContext _context;

    public AgendamentoAlunoRepository(AgendamentoAlunoDbContext context)
    {
        _context = context;
    }

    /*
    public async Task<int> ObterTotalAgendamentosAlunoMesAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken)
    {
        return await _context.AgendamentoAluno
            .CountAsync(x =>
                x.id_aluno == id_aluno &&
                x.dt_aula.Year == ano &&
                x.dt_aula.Month == mes,
                cancellationToken);
    }

    public async Task<int> ObterTotalAgendadosNaAulaAsync(long id_aula, DateTime dt_aula, CancellationToken cancellationToken)
    {
        return await _context.AgendamentoAluno.CountAsync(x => x.id_aula == id_aula && x.dt_aula == dt_aula, cancellationToken);
    }*/

    public async Task<AgendamentoAluno> CriarAsync(AgendamentoAluno agendamento, CancellationToken cancellationToken)
    {
        await _context.AgendamentoAluno.AddAsync(agendamento, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // Recarrega os dados
        await _context.Entry(agendamento).ReloadAsync(cancellationToken);
        return agendamento;
    }
}
