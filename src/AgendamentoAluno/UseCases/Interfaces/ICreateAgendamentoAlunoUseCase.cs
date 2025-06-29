namespace SistemaAgendamento.AgendamentoAluno;

public interface ICreateAgendamentoAlunoUseCase
{
    Task<AgendamentoAluno> ExecutarAsync(CreateAgendamentoAlunoDTO dto, CancellationToken cancellationToken);
}
