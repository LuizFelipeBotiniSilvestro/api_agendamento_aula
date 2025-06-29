using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> VerificarAlunoExisteAsync(long id_aluno, CancellationToken cancellationToken)
    {
        return await _context.Alunos.AnyAsync(a => a.Id == id_aluno, cancellationToken);
    }
}
