using SistemaAgendamento.Aula;

namespace SistemaAgendamento.AgendamentoAula;

public class CreateAgendamentoAulaUseCase : ICreateAgendamentoAulaUseCase
{
    private readonly IAgendamentoAulaRepository _repository;
     private readonly IAulaRepository _aulaRepository;
    private readonly ILogger<CreateAgendamentoAulaUseCase> _logger;

    public CreateAgendamentoAulaUseCase(
                                        IAgendamentoAulaRepository repository,
                                        IAulaRepository aulaRepository,
                                        ILogger<CreateAgendamentoAulaUseCase> logger
                                       )
    {
        _repository = repository;
        _aulaRepository = aulaRepository;
        _logger = logger;
    }

    public async Task<AgendamentoAula> ExecuteAsync(CreateAgendamentoAulaDto dto, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando validação do agendamento de aula");

        if (dto.id_aula <= 0)
            throw new ArgumentException("O ID da aula é obrigatório.");

        if (dto.dt_aula == default)
            throw new ArgumentException("A data da aula é obrigatória.");

        // Valida se a aula existe
        var aulaExistente = await _aulaRepository.BuscarPorIdAsync(dto.id_aula, cancellationToken);
        if (aulaExistente is null)
            throw new ArgumentException("A aula informada não existe.");

        /*
             Normaliza a data de entrada (UTC)
            O que essa validação faz:
            SpecifyKind garante que dto.dt_aula seja interpretado como UTC.

            AddTicks(-(Ticks % TicksPerSecond)) remove os milissegundos para evitar comparações imprecisas.

            Ambos os valores são comparados no mesmo fuso (UTC) e com a mesma granularidade (segundos).
        */
        var dataAula = DateTime.SpecifyKind(dto.dt_aula, DateTimeKind.Utc).AddTicks(-(dto.dt_aula.Ticks % TimeSpan.TicksPerSecond));
        var agora = DateTime.UtcNow.AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond));

        if (dataAula < agora)
            throw new ArgumentException("Não é possível agendar uma aula com data/hora no passado.");

        var agendamento = new AgendamentoAula
        {
            id_aula = dto.id_aula,
            dt_aula = dto.dt_aula
        };

        var result = await _repository.CriarAsync(agendamento, cancellationToken);

        _logger.LogInformation("Agendamento criado com sucesso. ID: {Id}", result.Id);

        return result;
    }
}
