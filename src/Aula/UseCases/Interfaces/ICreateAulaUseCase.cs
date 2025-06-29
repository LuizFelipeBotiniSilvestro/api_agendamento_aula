namespace SistemaAgendamento.Aula;

public interface ICreateAulaUseCase
{
    Task<Aula?> ExecuteAsync(CreateAulaDto request, CancellationToken cancellationToken);
}
