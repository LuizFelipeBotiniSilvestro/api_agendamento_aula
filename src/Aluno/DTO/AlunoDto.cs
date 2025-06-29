namespace SistemaAgendamento.Aluno;

public class AlunoDto
{
    public long id { get; set; }
    public string nm_aluno { get; set; } = string.Empty;
    public string tp_plano { get; set; } = string.Empty;
    public DateTime dt_inc { get; set; }
}
