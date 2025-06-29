namespace SistemaAgendamento.Aula;

public interface IGetAulasUseCase
{
    Task<List<AulaDto>> ExecutarAsync(CancellationToken cancellationToken);
}
