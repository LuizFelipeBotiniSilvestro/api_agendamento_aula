using Microsoft.EntityFrameworkCore;
using Npgsql;
using SistemaAgendamento.AgendamentoAula;
using SistemaAgendamento.Aluno;
using SistemaAgendamento.Aula;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoRepository : IAgendamentoAlunoRepository
{
    private readonly AgendamentoAlunoDbContext _context;
    private readonly AgendamentoAulaDbContext _agendamentoAulaDbContext;
    private readonly AlunoDbContext _alunoContext;
    private readonly AulaDbContext _aulaContext;

    public AgendamentoAlunoRepository(
                                      AgendamentoAlunoDbContext context,
                                      AgendamentoAulaDbContext agendamentoAulaDbContext,
                                      AlunoDbContext alunoContext,
                                      AulaDbContext aulaContext
                                     )
    {
        _context = context;
        _agendamentoAulaDbContext = agendamentoAulaDbContext; 
        _alunoContext = alunoContext;
        _aulaContext = aulaContext;
    }

    public async Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, DateTime dataReferencia, CancellationToken cancellationToken)
    {
        var primeiroDia = new DateTime(dataReferencia.Year, dataReferencia.Month, 1);
        var ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);

        return await _context.AgendamentoAluno
            .CountAsync(x => x.id_aluno == id_aluno &&
                             x.dt_inc >= primeiroDia &&
                             x.dt_inc <= ultimoDia, cancellationToken);
    }

    public async Task<int> ObterTotalAlunosNaAula(long id_agendamento_aula, CancellationToken cancellationToken)
    {
        return await _context.AgendamentoAluno.CountAsync(x => x.id_agendamento_aula == id_agendamento_aula, cancellationToken);
    }

    public async Task<AgendamentoAlunoEntity> CriarAsync(AgendamentoAlunoEntity entity, CancellationToken cancellationToken)
    {
        await _context.AgendamentoAluno.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<GetAgendamentoAlunoResult>> GetAsync(CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                aa.id,
                aa.id_aluno,
                a.nm_aluno,
                aa.id_agendamento_aula,
                ag.id_aula,
                au.nm_aula,
                ag.dt_aula,
                aa.dt_inc
            FROM agendamento.tb_agendamento_aluno aa
            INNER JOIN cadastro.tb_aluno a ON a.id = aa.id_aluno
            INNER JOIN agendamento.tb_agendamento_aula ag ON ag.id = aa.id_agendamento_aula
            INNER JOIN cadastro.tb_aula au ON au.id = ag.id_aula
        ";

        return await _context
            .Set<GetAgendamentoAlunoResult>()
            .FromSqlRaw(sql)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<GetTiposAulaMaisFrequentesResult>> ObterTiposAulaMaisFrequentesPorAlunoAsync(long id_aluno, CancellationToken cancellationToken)
    {
        var sql = @"
            SELECT 
                a.tp_aula,
                CASE a.tp_aula
                    WHEN 1 THEN 'Cross'
                    WHEN 2 THEN 'Musculação'
                    WHEN 3 THEN 'Pilates'
                    WHEN 4 THEN 'Spinning'
                    ELSE 'Desconhecido'
                END as nm_tipo_aula,
                COUNT(*) as total
            FROM agendamento.tb_agendamento_aluno aa
            JOIN agendamento.tb_agendamento_aula ag ON ag.id = aa.id_agendamento_aula
            JOIN cadastro.tb_aula a ON a.id = ag.id_aula
            WHERE aa.id_aluno = @id_aluno
            GROUP BY a.tp_aula
            ORDER BY total DESC";

        var param = new NpgsqlParameter("id_aluno", id_aluno);

        return await _context.Database.SqlQueryRaw<GetTiposAulaMaisFrequentesResult>(sql, param).ToListAsync(cancellationToken);
    }
}
