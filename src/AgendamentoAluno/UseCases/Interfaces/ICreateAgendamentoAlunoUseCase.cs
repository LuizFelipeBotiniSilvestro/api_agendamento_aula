namespace SistemaAgendamento.AgendamentoAluno;

public interface ICreateAgendamentoAlunoUseCase
{
    Task<AgendamentoAlunoEntity> ExecutarAsync(CreateAgendamentoAlunoDto dto, CancellationToken cancellationToken);
}
