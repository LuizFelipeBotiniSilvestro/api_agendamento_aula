namespace SistemaAgendamento.AgendamentoAula;

public interface IGetAgendamentoAulaUseCase
{
    Task<List<GetAgendamentoAulaResult>> ExecuteAsync(CancellationToken cancellationToken);
}
