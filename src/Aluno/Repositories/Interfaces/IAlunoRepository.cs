namespace SistemaAgendamento.Aluno;

public interface IAlunoRepository
{
    Task<Aluno> CreateAsync(Aluno aluno, CancellationToken cancellationToken);
}
