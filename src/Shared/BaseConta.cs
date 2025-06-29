using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public abstract class BaseConta
{
    [Key]
    [Column("id")]
    [ReadOnly(true)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }

    [Column("dt_inc")]
    public DateTime dt_inc { get; set; } // preenchida automaticamente no banco
}
