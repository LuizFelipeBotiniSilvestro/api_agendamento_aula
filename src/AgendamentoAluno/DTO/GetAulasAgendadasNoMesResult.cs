namespace SistemaAgendamento.AgendamentoAluno;

public class GetAulasAgendadasNoMesResult
{
    public long id_agendamento { get; set; }
    public string nm_aula { get; set; } = string.Empty;
    public long tp_aula { get; set; }
    public DateTime dt_aula { get; set; }
    public DateTime dt_inc { get; set; }
}
