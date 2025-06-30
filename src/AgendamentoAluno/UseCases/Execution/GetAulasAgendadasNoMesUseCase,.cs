namespace SistemaAgendamento.AgendamentoAluno;

public class GetAulasAgendadasNoMesUseCase : IGetAulasAgendadasNoMesUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;

    public GetAulasAgendadasNoMesUseCase(IAgendamentoAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAulasAgendadasNoMesResult>> ExecuteAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken)
    {
        return await _repository.GetAulasAgendadasNoMesAsync(id_aluno, ano, mes, cancellationToken);
    }
}


