namespace SistemaAgendamento.AgendamentoAluno;

public interface IAgendamentoAlunoRepository
{
    Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, DateTime dataReferencia, CancellationToken cancellationToken);
    Task<int> ObterTotalAlunosNaAula(long id_agendamento_aula, CancellationToken cancellationToken);
    Task<AgendamentoAlunoEntity> CriarAsync(AgendamentoAlunoEntity entity, CancellationToken cancellationToken);
    Task<List<GetAgendamentoAlunoResult>> GetAsync(CancellationToken cancellationToken);

    //
    Task<List<GetTiposAulaMaisFrequentesResult>> ObterTiposAulaMaisFrequentesPorAlunoAsync(long id_aluno, CancellationToken cancellationToken);
    Task<List<GetAulasAgendadasNoMesResult>> GetAulasAgendadasNoMesAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken);
    Task<int> ObterVagasRestantesAsync(long id_agendamento_aula, CancellationToken cancellationToken);
    Task<int> ObterTotalAgendamentosAlunoNoMes(long id_aluno, int ano, int mes, CancellationToken cancellationToken);

}
