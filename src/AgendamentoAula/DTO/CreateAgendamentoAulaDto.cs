using System.ComponentModel.DataAnnotations;

namespace SistemaAgendamento.AgendamentoAula;

public class CreateAgendamentoAulaDto
{
    [Required(ErrorMessage = "O campo 'id_aula' é obrigatório.")]
    public long id_aula { get; set; }

    [Required(ErrorMessage = "O campo 'dt_aula' é obrigatório.")]
    public DateTime dt_aula { get; set; }
}
