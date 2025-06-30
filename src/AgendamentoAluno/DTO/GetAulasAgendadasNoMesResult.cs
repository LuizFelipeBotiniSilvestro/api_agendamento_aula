namespace SistemaAgendamento.AgendamentoAluno;

public class GetAulasAgendadasNoMesResult
{
    public string nm_aluno { get; set; } = string.Empty;
    public long id_agendamento_aula { get; set; }
    public DateTime dt_aula { get; set; }
    public string nm_aula { get; set; } = string.Empty;
    public string tp_aula { get; set; } = string.Empty;
}
