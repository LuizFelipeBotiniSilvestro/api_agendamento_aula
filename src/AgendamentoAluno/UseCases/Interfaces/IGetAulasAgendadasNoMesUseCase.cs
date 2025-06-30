namespace SistemaAgendamento.AgendamentoAluno;

public interface IGetAulasAgendadasNoMesUseCase
{
    Task<List<GetAulasAgendadasNoMesResult>> ExecuteAsync(long id_aluno, int ano, int mes, CancellationToken cancellationToken);
}
