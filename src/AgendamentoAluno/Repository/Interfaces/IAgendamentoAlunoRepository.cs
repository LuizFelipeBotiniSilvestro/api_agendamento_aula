namespace SistemaAgendamento.AgendamentoAluno;

public interface IAgendamentoAlunoRepository
{
    Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, DateTime dataReferencia, CancellationToken cancellationToken);
    Task<int> ObterTotalAlunosNaAula(long id_agendamento_aula, CancellationToken cancellationToken);
    Task<AgendamentoAlunoEntity> CriarAsync(AgendamentoAlunoEntity entity, CancellationToken cancellationToken);
    Task<List<GetAgendamentoAlunoResult>> GetAsync(CancellationToken cancellationToken);
}
