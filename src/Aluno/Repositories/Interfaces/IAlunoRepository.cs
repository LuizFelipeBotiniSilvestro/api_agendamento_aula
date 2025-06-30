namespace SistemaAgendamento.Aluno;

public interface IAlunoRepository
{
    Task<Aluno> CreateAsync(Aluno aluno, CancellationToken cancellationToken);

    Task<List<Aluno>> ListarAsync(CancellationToken cancellationToken);

    Task<bool> VerificarAlunoExisteAsync(long id_aluno, CancellationToken cancellationToken);
    
    //
    Task<LimitePlanoAlunoResult> ObterLimitePlanoAlunoAsync(long id_aluno, CancellationToken cancellationToken);
}
