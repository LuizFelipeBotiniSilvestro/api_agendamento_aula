using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAgendamento.AgendamentoAluno;

public class AgendamentoAlunoEntity : BaseConta
{
    [Column("id_aluno")]
    public long id_aluno { get; set; }

    [Column("id_agendamento_aula")]
    public long id_agendamento_aula { get; set; }

    // Relacionamentos 
    // public AlunoEntity? Aluno { get; set; }
    // public AgendamentoAulaEntity? AgendamentoAula { get; set; }
}
