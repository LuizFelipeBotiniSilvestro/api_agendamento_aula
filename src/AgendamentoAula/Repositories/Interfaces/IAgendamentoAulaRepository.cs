namespace SistemaAgendamento.AgendamentoAula;

public interface IAgendamentoAulaRepository
{
    Task<AgendamentoAula> CriarAsync(AgendamentoAula agendamento, CancellationToken cancellationToken);

    Task<bool> VerificarAgendamentoAulaExisteAsync(long id_agendamento_aula, CancellationToken cancellationToken);

    Task<List<GetAgendamentoAulaResult>> GetAgendamentoAulaAsync(CancellationToken cancellationToken);

    Task<DateTime> ObterDataAulaAsync(long id_agendamento_aula, CancellationToken cancellationToken);
}
