namespace SistemaAgendamento.AgendamentoAluno;

public class GetAgendamentoAlunoUseCase: IGetAgendamentoAlunoUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;

    public GetAgendamentoAlunoUseCase(IAgendamentoAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAgendamentoAlunoResult>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(cancellationToken);
    }
}
