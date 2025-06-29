using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.AgendamentoAluno;

[ApiController]
[Route("api/agendamento-aluno")]
public class AgendamentoAlunoController : ControllerBase
{
    private readonly ICreateAgendamentoAlunoUseCase _createUseCase;

    public AgendamentoAlunoController(ICreateAgendamentoAlunoUseCase createUseCase)
    {
        _createUseCase = createUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAgendamentoAlunoDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var resultado = await _createUseCase.ExecutarAsync(dto, cancellationToken);
            return Ok(resultado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = $"Erro interno: {ex.Message}" });
        }
    }
}
