namespace SistemaAgendamento.Aula;

public class AulaDto
{
    public long Id { get; set; }
    public string nm_aula { get; set; } = string.Empty;
    public string tp_aula { get; set; } = string.Empty;
    public int nr_capacidade { get; set; }
}
