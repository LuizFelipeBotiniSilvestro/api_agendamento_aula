namespace SistemaAgendamento.Aluno;

public class CreateAlunoUseCase : ICreateAlunoUseCase
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly ILogger<CreateAlunoUseCase> _logger;

    public CreateAlunoUseCase(IAlunoRepository alunoRepository, ILogger<CreateAlunoUseCase> logger)
    {
        _alunoRepository = alunoRepository;
        _logger = logger;
    }

    public async Task<Aluno> ExecuteAsync(Aluno aluno, CancellationToken cancellationToken)
    {
        ValidarAluno(aluno);

        try
        {
            var tipo = PlanoTipoHelper.Parse(aluno.tp_plano);
            aluno.tp_plano = PlanoTipoHelper.ToCodigo(tipo);

            var criado = await _alunoRepository.CreateAsync(aluno, cancellationToken);
            _logger.LogInformation("Aluno criado com sucesso. ID: {id}", criado.Id);
            return criado;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar aluno.");
            throw new InvalidOperationException("Erro ao criar aluno.", ex);
        }
    }

    private void ValidarAluno(Aluno aluno)
    {
        if (string.IsNullOrWhiteSpace(aluno.nm_aluno))
            throw new ArgumentException("O campo 'nm_aluno' é obrigatório.");

        try
        {
            // Valida e converte: aceita "mensal", "MENSAL", 1 etc.
            var tipo = PlanoTipoHelper.Parse(aluno.tp_plano);

            // Reforça validação explícita de valores permitidos
            if (!Enum.IsDefined(typeof(PlanoTipo), tipo))
                throw new ArgumentException();
        }
        catch
        {
            throw new ArgumentException("O campo 'tp_plano' é inválido. Use: 1, 2, 3 ou Mensal, Trimestral, Anual.");
        }

    }
}
