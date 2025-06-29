namespace SistemaAgendamento.AgendamentoAluno;

public interface IGetAgendamentoAlunoUseCase
{
   Task<List<GetAgendamentoAlunoResult>> ExecuteAsync(CancellationToken cancellationToken);
}
