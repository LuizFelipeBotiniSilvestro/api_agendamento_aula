namespace SistemaAgendamento.AgendamentoAluno;

public class GetAgendamentoAlunoResult
{
    public long id { get; set; }
    public long id_aluno { get; set; }
    public string nm_aluno { get; set; } = string.Empty;
    public long id_agendamento_aula { get; set; }
    public long id_aula { get; set; }
    public string nm_aula { get; set; } = string.Empty;
    public DateTime dt_aula { get; set; }
}
