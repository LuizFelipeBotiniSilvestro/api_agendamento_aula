namespace SistemaAgendamento.Aluno;

public interface ICreateAlunoUseCase
{
    Task<Aluno> ExecuteAsync(Aluno aluno, CancellationToken cancellationToken);
}
