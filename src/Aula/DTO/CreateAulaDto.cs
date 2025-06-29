using System.ComponentModel.DataAnnotations;

namespace SistemaAgendamento.Aula;

public class CreateAulaDto
{
    [Required(ErrorMessage = "O campo 'nm_aula' é obrigatório.")]
    public string nm_aula { get; set; }

    [Required(ErrorMessage = "O campo 'tp_aula' é obrigatório.")]
    public object tp_aula { get; set; }

    [Required(ErrorMessage = "O campo 'nr_capacidade' é obrigatório.")]
    public int nr_capacidade { get; set; }
}
