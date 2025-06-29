using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAgendamento.AgendamentoAula;

[Table("tb_agendamento_aula")]
public class AgendamentoAula : BaseConta
{
    [Column("id_aula")]
    [ForeignKey(nameof(Aula))]
    public long id_aula { get; set; }

    [Column("dt_aula")]
    public DateTime dt_aula { get; set; }

    // Navegação
    public SistemaAgendamento.Aula.Aula? Aula { get; set; }
}
