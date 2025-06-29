using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAgendamento.Aluno;

[Table("tb_aluno", Schema = "aluno")]
public class Aluno : BaseConta
{
    [Required]
    [Column("nm_aluno")]
    public string nm_aluno { get; set; } = "";

    [Required]
    [Column("tp_plano")]
    public long tp_plano { get; set; } // "1 - Mensal", "2 - Trimestral", "3 - Anual"
}
