using SistemaAgendamento.Aluno;
using SistemaAgendamento.Aula;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAgendamento.AgendamentoAluno;

[Table("tb_agendamento_aluno")]
public class AgendamentoAluno : BaseConta
{
    [Column("id_aluno")]
    public long id_aluno { get; set; }

    [Column("id_aula")]
    public long id_aula { get; set; }

    // Navigation properties
    public Aluno.Aluno? Aluno { get; set; }
    public Aula.Aula? Aula { get; set; }
}
