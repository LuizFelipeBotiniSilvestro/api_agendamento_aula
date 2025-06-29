namespace SistemaAgendamento.AgendamentoAluno;

public class GetTiposAulaMaisFrequentesUseCase : IGetTiposAulaMaisFrequentesUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;

    public GetTiposAulaMaisFrequentesUseCase(IAgendamentoAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTiposAulaMaisFrequentesResult>> ExecuteAsync(long id_aluno, CancellationToken cancellationToken)
    {
        return await _repository.ObterTiposAulaMaisFrequentesPorAlunoAsync(id_aluno, cancellationToken);
    }
}

