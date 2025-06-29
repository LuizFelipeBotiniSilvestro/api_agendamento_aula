using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.AgendamentoAluno;

[ApiController]
[Route("api/agendamento-aluno")]
public class AgendamentoAlunoController : ControllerBase
{
    private readonly ICreateAgendamentoAlunoUseCase _createUseCase;
    private readonly IGetAgendamentoAlunoUseCase _getUseCase;

    public AgendamentoAlunoController(ICreateAgendamentoAlunoUseCase createUseCase,
                                      IGetAgendamentoAlunoUseCase getUseCase
                                      )
    {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
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

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _getUseCase.ExecuteAsync(cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
