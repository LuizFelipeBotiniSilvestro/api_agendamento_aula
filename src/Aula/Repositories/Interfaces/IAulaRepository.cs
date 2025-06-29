namespace SistemaAgendamento.Aula;

public interface IAulaRepository
{
    Task<Aula> CriarAsync(Aula aula, CancellationToken cancellationToken);
}
