namespace SistemaAgendamento.Aula;

public class CreateAulaUseCase : ICreateAulaUseCase
{
    private readonly IAulaRepository _repository;
    private readonly ILogger<CreateAulaUseCase> _logger;

    public CreateAulaUseCase(IAulaRepository repository, ILogger<CreateAulaUseCase> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Aula?> ExecuteAsync(CreateAulaDto request, CancellationToken cancellationToken)
    {
        ValidarCampos(request);

        var aula = new Aula
        {
            nm_aula = request.nm_aula,
            tp_aula = TipoAulaHelper.Parse(request.tp_aula),
            nr_capacidade = request.nr_capacidade
        };

        var id = await _repository.CriarAsync(aula, cancellationToken);
        _logger.LogInformation("Aula cadastrada com ID {Id}.", id);

        return aula;
    }

    private void ValidarCampos(CreateAulaDto request)
    {
        if (request.nm_aula == null)
            throw new ArgumentException("O campo 'nm_aula' é obrigatório.");

        if (request.tp_aula == null)
            throw new ArgumentException("O campo 'tp_aula' é obrigatório.");

        if (request.nr_capacidade == null)
            throw new ArgumentException("O campo 'nr_capacidade' é obrigatório.");

        if (request.nr_capacidade <= 0)
            throw new ArgumentException("O campo 'nr_capacidade' deve ser maior que zero.");
    }
}
