using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoRepository : IAgendamentoAlunoRepository
{
    private readonly AgendamentoAlunoDbContext _context;

    public AgendamentoAlunoRepository(
                                      AgendamentoAlunoDbContext context
                                     )
    {
        _context = context;
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

    public async Task<List<GetAulasAgendadasNoMesResult>> GetAulasAgendadasNoMesAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken)
    {
        var sql = $@"
            SELECT 
                aluno.nm_aluno,
                agendamento.id AS id_agendamento_aula,
                aa.dt_aula,
                aula.nm_aula,
                CASE aula.tp_aula 
                    WHEN 1 THEN 'Cross'
                    WHEN 2 THEN 'Musculação'
                    WHEN 3 THEN 'Pilates'
                    WHEN 4 THEN 'Spinning'
                    ELSE 'Desconhecido'
                END AS tp_aula
            FROM agendamento.tb_agendamento_aluno agendamento
            INNER JOIN cadastro.tb_aluno aluno ON aluno.id = agendamento.id_aluno
            INNER JOIN agendamento.tb_agendamento_aula aa ON aa.id = agendamento.id_agendamento_aula
            INNER JOIN cadastro.tb_aula aula ON aula.id = aa.id_aula
            WHERE agendamento.id_aluno = @id_aluno
            AND EXTRACT(MONTH FROM aa.dt_aula) = @mes
            AND EXTRACT(YEAR FROM aa.dt_aula) = @ano
            ORDER BY aa.dt_aula ASC";

        var parametros = new[]
        {
            new NpgsqlParameter("id_aluno", id_aluno),
            new NpgsqlParameter("mes", mes),
            new NpgsqlParameter("ano", ano)
        };

        return await _context.Database
            .SqlQueryRaw<GetAulasAgendadasNoMesResult>(sql, parametros)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> ObterVagasRestantesAsync(long id_agendamento_aula, CancellationToken cancellationToken)
    {
        var sql = @"
            SELECT 
                (aula.nr_capacidade - COUNT(agendamento_aluno.id)) AS vagas_restantes
            FROM agendamento.tb_agendamento_aula agendamento_aula
            INNER JOIN cadastro.tb_aula aula ON aula.id = agendamento_aula.id_aula
            LEFT JOIN agendamento.tb_agendamento_aluno agendamento_aluno ON agendamento_aluno.id_agendamento_aula = agendamento_aula.id
            WHERE agendamento_aula.id = @id_agendamento_aula
            GROUP BY aula.nr_capacidade";

        var param = new NpgsqlParameter("id_agendamento_aula", id_agendamento_aula);

        var resultado = await _context.Database
            .SqlQueryRaw<VagasRestantesResult>(sql, [param])
            .FirstOrDefaultAsync(cancellationToken);

        return resultado?.vagas_restantes ?? 0;
    }

    public async Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, int ano, int mes, CancellationToken cancellationToken)
    {
        const string sql = @"
                           SELECT 
                              COUNT(*) AS total_agendamentos
                           FROM agendamento.tb_agendamento_aluno aluno
                           INNER JOIN agendamento.tb_agendamento_aula aula ON aula.id = aluno.id_agendamento_aula
                            WHERE aluno.id_aluno = @id_aluno
                            AND DATE_PART('year', aula.dt_aula) = @ano
                            AND DATE_PART('month', aula.dt_aula) = @mes
                            ";

        var parametros = new[]
        {
            new NpgsqlParameter("id_aluno", id_aluno),
            new NpgsqlParameter("ano", ano),
            new NpgsqlParameter("mes", mes)
        };

        var resultado = await _context.Database
            .SqlQueryRaw<TotalAgendamentosAlunoResult>(sql, parametros)
            .FirstOrDefaultAsync(cancellationToken);

        return resultado?.total_agendamentos ?? 0;
    }


}
