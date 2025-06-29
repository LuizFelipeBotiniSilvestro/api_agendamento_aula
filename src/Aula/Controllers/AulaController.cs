using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.Aula;

[ApiController]
[Route("v1/aula")]
public class AulaController : ControllerBase
{
    private readonly ICreateAulaUseCase _createAulaUseCase;
    private readonly IGetAulasUseCase _getAulasUseCase;
    private readonly ILogger<AulaController> _logger;

    public AulaController(ICreateAulaUseCase createAulaUseCase, 
                          IGetAulasUseCase getAulasUseCase,
                          ILogger<AulaController> logger
                         )
    {
        _createAulaUseCase = createAulaUseCase;
        _getAulasUseCase = getAulasUseCase;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAulaDto request, CancellationToken cancellationToken)
    {
        try
        {
            var aula = await _createAulaUseCase.ExecuteAsync(request, cancellationToken);
            return Ok(aula);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação ao criar aula.");
            return BadRequest(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado ao criar aula.");
            return StatusCode(500, new { erro = "Erro inesperado ao criar aula." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        try
        {
            var aulas = await _getAulasUseCase.ExecutarAsync(cancellationToken);
            return Ok(aulas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter aulas: {ex.Message}");
        }
    }

}
