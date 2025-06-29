namespace SistemaAgendamento.Aula;

public interface ICreateAulaUseCase
{
    Task<Aula?> ExecuteAsync(AulaRequest request, CancellationToken cancellationToken);
}
