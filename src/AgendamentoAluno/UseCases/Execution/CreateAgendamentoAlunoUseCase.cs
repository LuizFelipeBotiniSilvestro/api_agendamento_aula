using SistemaAgendamento.AgendamentoAula;
using SistemaAgendamento.Aluno;
using SistemaAgendamento.Aula;

namespace SistemaAgendamento.AgendamentoAluno;

public class CreateAgendamentoAlunoUseCase : ICreateAgendamentoAlunoUseCase
{
    private readonly IAgendamentoAlunoRepository _repository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IAgendamentoAulaRepository _agendamentoAulaRepository;


    public CreateAgendamentoAlunoUseCase(
                                          IAgendamentoAlunoRepository repository,
                                          IAlunoRepository alunoRepository,
                                          IAgendamentoAulaRepository agendamentoAulaRepository
                                          )
    {
        _repository = repository;
        _alunoRepository = alunoRepository;
        _agendamentoAulaRepository = agendamentoAulaRepository;
    }

    public async  Task<AgendamentoAlunoEntity> ExecutarAsync(CreateAgendamentoAlunoDto dto, CancellationToken cancellationToken)
    {
        if (!await _alunoRepository.VerificarAlunoExisteAsync(dto.id_aluno, cancellationToken))
            throw new ArgumentException("Aluno não encontrado.");

        // id_agendamento_aula é por exemplo: pilates 30/06/2025 20:00h
        if (!await _agendamentoAulaRepository.VerificarAgendamentoAulaExisteAsync(dto.id_agendamento_aula, cancellationToken))
            throw new ArgumentException("Agendamento de aula não encontrado.");

        // Verifica se tem a quantidade disponível
        var qtdeDisponivel = await _repository.ObterVagasRestantesAsync(dto.id_agendamento_aula, cancellationToken);
        if (qtdeDisponivel <= 0)
            throw new ArgumentException("Capacidade máxima da aula atingida.");

        // Obtém os dados da aula
        var dataAula = await _agendamentoAulaRepository.ObterDataAulaAsync(dto.id_agendamento_aula, cancellationToken);
        var ano = dataAula.Year;
        var mes = dataAula.Month;

        // Obtém o plano do aluno
        var plano = await _alunoRepository.ObterLimitePlanoAlunoAsync(dto.id_aluno, cancellationToken);

        // Conta quantos agendamentos o aluno já tem no mês
        var totalAgendado = await _repository.ObterTotalAgendamentosAlunoNoMes(dto.id_aluno, ano, mes, cancellationToken);
        if (totalAgendado > plano.limite_agendamentos)
            throw new ArgumentException($"Limite de agendamentos mensais do plano atingido ({plano.limite_agendamentos} aulas/mês).");

        var entity = new AgendamentoAlunoEntity
        {
            id_aluno = dto.id_aluno,
            id_agendamento_aula = dto.id_agendamento_aula
        };

        return await _repository.CriarAsync(entity, cancellationToken);
    }
}
