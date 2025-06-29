namespace SistemaAgendamento.Aluno;

public class CreateAlunoRequest
{
    public string? nm_aluno { get; set; }
    public string? tp_plano { get; set; } // aceita "mensal" ou "1", "2" etc.
}
