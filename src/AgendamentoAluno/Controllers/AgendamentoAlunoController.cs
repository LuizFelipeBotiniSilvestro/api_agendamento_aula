using Microsoft.AspNetCore.Mvc;

namespace SistemaAgendamento.AgendamentoAluno;

[ApiController]
[Route("api/agendamento-aluno")]
public class AgendamentoAlunoController : ControllerBase
{
    private readonly ICreateAgendamentoAlunoUseCase _createUseCase;
    private readonly IGetAgendamentoAlunoUseCase _getUseCase;
    private readonly IGetTiposAulaMaisFrequentesUseCase _getTiposAulaMaisFrequentesPorAlunoUseCase;
    private readonly IGetAulasAgendadasNoMesUseCase _getAulasAgendadasNoMesUseCase;

    public AgendamentoAlunoController(ICreateAgendamentoAlunoUseCase createUseCase,
                                      IGetAgendamentoAlunoUseCase getUseCase,
                                      IGetTiposAulaMaisFrequentesUseCase getTiposAulaMaisFrequentesPorAlunoUseCase,
                                      IGetAulasAgendadasNoMesUseCase getAulasAgendadasNoMesUseCase
                                      )
    {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
        _getTiposAulaMaisFrequentesPorAlunoUseCase = getTiposAulaMaisFrequentesPorAlunoUseCase;
        _getAulasAgendadasNoMesUseCase = getAulasAgendadasNoMesUseCase;
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

    [HttpGet("getTiposAulaMaisFrequentes/{id_aluno:long}")]
    public async Task<IActionResult> GetTiposAulaMaisFrequentes(long id_aluno, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _getTiposAulaMaisFrequentesPorAlunoUseCase.ExecuteAsync(id_aluno, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("getAulasAgendadasNoMes/{id_aluno}/{ano}/{mes}")]
    public async Task<IActionResult> GetAulasAgendadasNoMes(long id_aluno, int ano, int mes, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _getAulasAgendadasNoMesUseCase.ExecuteAsync(id_aluno, ano, mes, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

}
