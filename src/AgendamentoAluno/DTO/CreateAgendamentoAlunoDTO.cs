namespace SistemaAgendamento.AgendamentoAluno;

public class CreateAgendamentoAlunoDTO
{
    public long id_aluno { get; set; } // Id do aluno
    public long id_aula { get; set; } // Id da aula (já com tipo, data, etc...)
}
