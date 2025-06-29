namespace SistemaAgendamento.AgendamentoAluno;

public interface IAgendamentoAlunoRepository
{
    Task<bool> VerificarAlunoExisteAsync(long id_aluno, CancellationToken cancellationToken);
    Task<bool> VerificarAulaExisteAsync(long id_aula, CancellationToken cancellationToken);
    Task<bool> VerificarAgendamentoAulaExisteAsync(long id_agendamento_aula, CancellationToken cancellationToken);
    Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, DateTime dataReferencia, CancellationToken cancellationToken);
    Task<int> ObterTotalAlunosNaAula(long id_agendamento_aula, CancellationToken cancellationToken);
    Task<AgendamentoAlunoEntity> CriarAsync(AgendamentoAlunoEntity entity, CancellationToken cancellationToken);
}
