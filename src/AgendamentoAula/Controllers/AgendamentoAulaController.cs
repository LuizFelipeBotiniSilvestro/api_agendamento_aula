using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.AgendamentoAula;

[ApiController]
[Route("v1/agendamento-aula")]
public class AgendamentoAulaController : ControllerBase
{
    private readonly ICreateAgendamentoAulaUseCase _createUseCase;
    private readonly ILogger<AgendamentoAulaController> _logger;

    public AgendamentoAulaController(
                                      ICreateAgendamentoAulaUseCase createUseCase,
                                      ILogger<AgendamentoAulaController> logger
                                    )
    {
        _createUseCase = createUseCase;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(
                                                [FromBody] CreateAgendamentoAulaDto dto,
                                                CancellationToken cancellationToken
                                               )
    {
        try
        {
            var result = await _createUseCase.ExecuteAsync(dto, cancellationToken);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação no agendamento.");
            return BadRequest(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado ao criar agendamento.");
            return StatusCode(500, new { erro = "Erro interno no servidor." });
        }
    }
}
