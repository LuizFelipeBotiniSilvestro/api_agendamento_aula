namespace SistemaAgendamento.Aula;

public class GetAulasUseCase : IGetAulasUseCase
{
    private readonly IAulaRepository _repository;

    public GetAulasUseCase(IAulaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AulaDto>> ExecutarAsync(CancellationToken cancellationToken)
    {
        var aulas = await _repository.getAulasAsync(cancellationToken);

        return aulas.Select(a => new AulaDto
        {
            Id = a.Id.HasValue ? a.Id.Value : 0,
            nm_aula = a.nm_aula,
             tp_aula = TipoAulaHelper.ToNome(a.tp_aula),
            nr_capacidade = a.nr_capacidade,
            dt_inc = a.dt_inc
        }).ToList();
    }
}
