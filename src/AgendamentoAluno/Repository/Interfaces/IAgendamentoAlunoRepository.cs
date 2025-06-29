namespace SistemaAgendamento.AgendamentoAluno;

public interface IAgendamentoAlunoRepository
{
    /*Task<int> ObterTotalAgendamentosAlunoMesAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken);*/
    /*Task<int> ObterTotalAgendadosNaAulaAsync(long id_aula, DateTime dt_aula, CancellationToken cancellationToken);*/
    Task<AgendamentoAluno> CriarAsync(AgendamentoAluno agendamento, CancellationToken cancellationToken);
}
