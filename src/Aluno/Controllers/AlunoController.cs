using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.Aluno;

[ApiController]
[Route("v1/aluno")]
public class AlunoController : ControllerBase
{
    private readonly ICreateAlunoUseCase _createAlunoUseCase;

     private readonly IGetAlunosUseCase _getAlunoUseCase;
    private readonly ILogger<AlunoController> _logger;

    public AlunoController(ICreateAlunoUseCase createAlunoUseCase, 
                           IGetAlunosUseCase getAlunoUseCase, 
                           ILogger<AlunoController> logger
                           )
    {
        _createAlunoUseCase = createAlunoUseCase;
        _getAlunoUseCase = getAlunoUseCase;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAlunoRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest("Dados do aluno são obrigatórios.");

        try
        {
            var aluno = new Aluno
            {
                nm_aluno = request.nm_aluno?.Trim() ?? string.Empty,
                tp_plano = PlanoTipoHelper.ToCodigo(PlanoTipoHelper.Parse(request.tp_plano))
            };
            
            var criado = await _createAlunoUseCase.ExecuteAsync(aluno, cancellationToken);
            return Ok(criado);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação ao criar aluno.");
            return BadRequest(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado ao criar aluno.");
            return StatusCode(500, "Erro interno ao processar a solicitação.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListarAsync(CancellationToken cancellationToken)
    {
        try
        {
            var alunos = await _getAlunoUseCase.ExecutarAsync(cancellationToken);
            return Ok(alunos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar alunos: {ex.Message}");
        }
    }

}
