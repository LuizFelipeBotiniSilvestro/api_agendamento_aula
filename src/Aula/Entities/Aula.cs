using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAgendamento.Aula;

[Table("tb_aula")]
public class Aula : BaseConta
{
    [Column("tp_aula")]
    public long tp_aula { get; set; }

    [Column("nr_capacidade")]
    public int nr_capacidade { get; set; }
}
