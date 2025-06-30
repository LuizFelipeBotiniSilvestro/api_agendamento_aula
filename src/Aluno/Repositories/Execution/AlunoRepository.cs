using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace SistemaAgendamento.Aluno;

public class AlunoRepository : IAlunoRepository
{
    private readonly AlunoDbContext _context;
    private readonly ILogger<AlunoRepository> _logger;

    public AlunoRepository(AlunoDbContext context, ILogger<AlunoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Aluno> CreateAsync(Aluno aluno, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Alunos.AddAsync(aluno, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            
            // Atualiza os campos gerados automaticamente, como dt_inc
            await _context.Entry(aluno).ReloadAsync(cancellationToken);

            return aluno;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao salvar aluno no banco de dados. Nome: {nome}", aluno.nm_aluno);
            throw;
        }
    }

    public async Task<List<Aluno>> ListarAsync(CancellationToken cancellationToken)
    {
        return await _context.Alunos.AsNoTracking().OrderByDescending(x => x.dt_inc).ToListAsync(cancellationToken);
    }

    public async Task<bool> VerificarAlunoExisteAsync(long id_aluno, CancellationToken cancellationToken)
    {
        return await _context.Alunos.AnyAsync(a => a.Id == id_aluno, cancellationToken);
    }

    //
   public async Task<LimitePlanoAlunoResult> ObterLimitePlanoAlunoAsync(long id_aluno, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                id AS id_aluno, 
                tp_plano
            FROM cadastro.tb_aluno
            WHERE id = @id_aluno";

        var param = new NpgsqlParameter("id_aluno", id_aluno);

        var aluno = await _context.Database
            .SqlQueryRaw<LimitePlanoAlunoResult>(sql, [param])
            .FirstOrDefaultAsync(cancellationToken);

        if (aluno is null)
            throw new ArgumentException("Aluno não encontrado.");

        var tipoPlano = PlanoTipoHelper.Parse(aluno.tp_plano);
        aluno.tp_plano = (long)tipoPlano;
        aluno.limite_agendamentos = tipoPlano switch
        {
            PlanoTipo.Mensal => 12,
            PlanoTipo.Trimestral => 20,
            PlanoTipo.Anual => 30,
            _ => throw new Exception("Plano inválido.")
        };

        return aluno;
    }


}
