namespace SistemaAgendamento.AgendamentoAluno;

public interface IGetTiposAulaMaisFrequentesUseCase
{
   Task<List<GetTiposAulaMaisFrequentesResult>> ExecuteAsync(long id_aluno, CancellationToken cancellationToken);
}
