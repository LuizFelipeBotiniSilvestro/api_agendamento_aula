namespace SistemaAgendamento.Aluno;

public class GetAlunosUseCase : IGetAlunosUseCase
{
    private readonly IAlunoRepository _repository;

    public GetAlunosUseCase(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AlunoDto>> ExecutarAsync(CancellationToken cancellationToken)
    {
        var alunos = await _repository.ListarAsync(cancellationToken);

        return alunos.Select(a => new AlunoDto
        {
            id = a.Id.HasValue ? a.Id.Value : 0,
            nm_aluno = a.nm_aluno,
            tp_plano = PlanoTipoHelper.ToNome((PlanoTipo)a.tp_plano),
            dt_inc = a.dt_inc
        }).ToList();
    }
}
