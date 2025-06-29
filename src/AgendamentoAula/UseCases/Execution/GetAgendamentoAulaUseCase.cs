namespace SistemaAgendamento.AgendamentoAula;

public class GetAgendamentoAulaUseCase : IGetAgendamentoAulaUseCase
{
    private readonly IAgendamentoAulaRepository _repository;

    public GetAgendamentoAulaUseCase(IAgendamentoAulaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAgendamentoAulaResult>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAgendamentoAulaAsync(cancellationToken);
    }
}
