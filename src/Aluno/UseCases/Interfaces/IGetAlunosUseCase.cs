namespace SistemaAgendamento.Aluno;

public interface IGetAlunosUseCase
{
    Task<List<AlunoDto>> ExecutarAsync(CancellationToken cancellationToken);
}
