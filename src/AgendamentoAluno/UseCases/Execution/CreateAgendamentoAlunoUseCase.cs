using SistemaAgendamento.Aula;
using SistemaAgendamento.Aluno;

namespace SistemaAgendamento.AgendamentoAluno;

public class CreateAgendamentoAlunoUseCase : ICreateAgendamentoAlunoUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IAulaRepository _aulaRepository;

    public CreateAgendamentoAlunoUseCase(
                                        IAgendamentoAlunoRepository repository,
                                        IAlunoRepository alunoRepository,
                                        IAulaRepository aulaRepository
                                        )
    {
        _repository = repository;
        _alunoRepository = alunoRepository;
        _aulaRepository = aulaRepository;
    }

    public async Task<AgendamentoAluno> ExecutarAsync(CreateAgendamentoAlunoDTO dto, CancellationToken cancellationToken)
    {
        if (dto.id_aluno <= 0)
            throw new ArgumentException("O id_aluno é obrigatório.");

        if (dto.id_aula <= 0)
            throw new ArgumentException("O id_aula é obrigatório.");

        var alunoExiste = await _alunoRepository.VerificarAlunoExisteAsync(dto.id_aluno, cancellationToken);
        if (!alunoExiste)
            throw new ArgumentException("Aluno não encontrado.");

        var aulaExiste = await _aulaRepository.VerificarAulaExisteAsync(dto.id_aula, cancellationToken);
        if (!aulaExiste)
            throw new ArgumentException("Aula não encontrada.");

        /*
        var capacidadeAtingida = await _repository.VerificarCapacidadeAtingidaAsync(dto.id_aula, dto.dt_aula, cancellationToken);
        if (capacidadeAtingida)
            throw new InvalidOperationException("Capacidade da aula atingida.");

        var excedeuLimite = await _repository.ExcedeuLimitePlanoAsync(dto.id_aluno, dto.dt_aula, cancellationToken);
        if (excedeuLimite)
            throw new InvalidOperationException("Aluno excedeu o limite de agendamentos permitidos pelo plano.");*/

        var agendamento = new AgendamentoAluno
        {
            id_aluno = dto.id_aluno,
            id_aula = dto.id_aula
        };

        return await _repository.CriarAsync(agendamento, cancellationToken);
    }
}
