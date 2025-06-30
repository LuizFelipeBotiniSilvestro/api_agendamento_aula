namespace SistemaAgendamento.Aluno;

public sealed class LimitePlanoAlunoResult
{
    public long id_aluno { get; set; }
    public long tp_plano { get; set; }
    public int limite_agendamentos { get; set; }
}
