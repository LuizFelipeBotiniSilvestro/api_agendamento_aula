using SistemaAgendamento.AgendamentoAula;
using SistemaAgendamento.Aluno;
using SistemaAgendamento.Aula;

namespace SistemaAgendamento.AgendamentoAluno;

public class CreateAgendamentoAlunoUseCase : ICreateAgendamentoAlunoUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IAgendamentoAulaRepository _agendamentoAulaRepository;

    private readonly IAulaRepository _aulaRepository;

    public CreateAgendamentoAlunoUseCase(
                                          IAgendamentoAlunoRepository repository,
                                          IAlunoRepository alunoRepository,
                                          IAulaRepository aulaRepository,
                                          IAgendamentoAulaRepository agendamentoAulaRepository
                                          )
    {
        _repository = repository;
        _alunoRepository = alunoRepository;
        _aulaRepository = aulaRepository;
        _agendamentoAulaRepository = agendamentoAulaRepository;
    }

    public async  Task<AgendamentoAlunoEntity> ExecutarAsync(CreateAgendamentoAlunoDto dto, CancellationToken cancellationToken)
    {
        if (!await _alunoRepository.VerificarAlunoExisteAsync(dto.id_aluno, cancellationToken))
            throw new ArgumentException("Aluno não encontrado.");

        // id_agendamento_aula é por exemplo: pilates 30/06/2025 20:00h
        if (!await _agendamentoAulaRepository.VerificarAgendamentoAulaExisteAsync(dto.id_agendamento_aula, cancellationToken))
            throw new ArgumentException("Agendamento de aula não encontrado.");

        var entity = new AgendamentoAlunoEntity
        {
            id_aluno = dto.id_aluno,
            id_agendamento_aula = dto.id_agendamento_aula
        };

        return await _repository.CriarAsync(entity, cancellationToken);
    }
}
