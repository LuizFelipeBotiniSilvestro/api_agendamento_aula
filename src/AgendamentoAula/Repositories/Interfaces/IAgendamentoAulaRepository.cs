namespace SistemaAgendamento.AgendamentoAula;

public interface IAgendamentoAulaRepository
{
    Task<AgendamentoAula> CriarAsync(AgendamentoAula agendamento, CancellationToken cancellationToken);
}
