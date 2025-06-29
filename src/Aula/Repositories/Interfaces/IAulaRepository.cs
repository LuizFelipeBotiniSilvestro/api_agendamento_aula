namespace SistemaAgendamento.Aula;

public interface IAulaRepository
{
    Task<Aula> CriarAsync(Aula aula, CancellationToken cancellationToken);

    Task<Aula?> BuscarPorIdAsync(long id, CancellationToken cancellationToken);

    Task<bool> VerificarAulaExisteAsync(long id_aula, CancellationToken cancellationToken);
}
