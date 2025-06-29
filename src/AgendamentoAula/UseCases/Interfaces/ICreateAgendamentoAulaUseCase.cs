namespace SistemaAgendamento.AgendamentoAula;

public interface ICreateAgendamentoAulaUseCase
{
    Task<AgendamentoAula> ExecuteAsync(CreateAgendamentoAulaDto dto, CancellationToken cancellationToken);
}
