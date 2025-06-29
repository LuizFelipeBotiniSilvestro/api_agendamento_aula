using SistemaAgendamento.Aluno;

namespace SistemaAgendamento.AgendamentoAluno;

public class CreateAgendamentoAlunoUseCase : ICreateAgendamentoAlunoUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;
    private readonly IAlunoRepository _alunoRepository;

    public CreateAgendamentoAlunoUseCase(
        IAgendamentoAlunoRepository repository,
        IAlunoRepository alunoRepository)
    {
        _repository = repository;
        _alunoRepository = alunoRepository;
    }

    public async  Task<AgendamentoAlunoEntity> ExecutarAsync(CreateAgendamentoAlunoDto dto, CancellationToken cancellationToken)
    {
        if (!await _repository.VerificarAlunoExisteAsync(dto.id_aluno, cancellationToken))
            throw new ArgumentException("Aluno não encontrado.");

        if (!await _repository.VerificarAulaExisteAsync(dto.id_aula, cancellationToken))
            throw new ArgumentException("Aula não encontrada.");

        // id_agendamento_aula é por exemplo: pilates 30/06/2025 20:00h
        if (!await _repository.VerificarAgendamentoAulaExisteAsync(dto.id_agendamento_aula, cancellationToken))
            throw new ArgumentException("Agendamento de aula não encontrado.");

    /*
        var plano = await _alunoRepository.ObterTipoPlanoAsync(dto.id_aluno, cancellationToken);
        var limite = plano switch
        {
            PlanoTipo.Mensal => 12,
            PlanoTipo.Trimestral => 20,
            PlanoTipo.Anual => 30,
            _ => throw new Exception("Plano inválido.")
        };

        var totalAgendado = await _repository.ObterTotalAgendamentosAlunoNoMes(dto.id_aluno, DateTime.UtcNow, cancellationToken);
        if (totalAgendado >= limite)
            throw new ArgumentException($"Limite de agendamentos mensais do plano {PlanoTipoHelper.ToNome(plano)} atingido.");

        var totalAlunos = await _repository.ObterTotalAlunosNaAula(dto.id_agendamento_aula, cancellationToken);
        var capacidade = await _alunoRepository.ObterCapacidadeAulaAsync(dto.id_aula, cancellationToken);
        if (totalAlunos >= capacidade)
            throw new ArgumentException("Capacidade máxima da aula atingida.");*/

        var entity = new AgendamentoAlunoEntity
        {
            id_aluno = dto.id_aluno,
            id_aula = dto.id_aula,
            id_agendamento_aula = dto.id_agendamento_aula
        };

        return await _repository.CriarAsync(entity, cancellationToken);
    }
}
