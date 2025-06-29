using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAgendamento.AgendamentoAula;

[Table("tb_agendamento_aula")]
public class AgendamentoAula : BaseConta
{
    [Column("id_aula")]
    public long id_aula { get; set; }

    [Column("dt_aula")]
    public DateTime dt_aula { get; set; }
}
