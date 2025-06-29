# Sistema de Agendamento

Sistema de agendamento de aulas coletivas para academias, desenvolvido em **.NET 8** com **PostgreSQL**.

## 📚 Visão Geral

Este sistema permite:

- Cadastro de **alunos**, com plano (Mensal, Trimestral, Anual)
- Cadastro de **aulas** (Cross, Musculação, Pilates, Spinning)
- **Agendamento** de alunos nas aulas
- Relatórios por aluno com total de agendamentos e aulas mais frequentadas

---

## 🧱 Estrutura do Projeto

/src
/Aluno
/Aula
/AgendamentoAula

- `Controllers/`, `UseCases/`, `Repositories/`, `Entities/`, `DTOs/` em cada módulo

---

## ⚙️ Tecnologias

- .NET 8
- ASP.NET Core Web API
- PostgreSQL (via Npgsql)
- Swagger (Swashbuckle)
- Injeção de Dependência nativa
- Boas práticas de arquitetura (Use Case → Repository → SQL)

---

## 🚀 Executando o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repo.git

2. Vá para a pasta da API:
    cd SistemaAgendamento.Api

3. Execute o projeto
    dotnet run

4. Acesse a documentação Swagger:
    http://localhost:5045/swagger

📌 Observações
A arquitetura é modularizada por domínio (Aluno, Aula, etc.).

O código segue boas práticas com validações, tratamento de erros e separação de responsabilidades.

Use CancellationToken em métodos assíncronos.

🧑‍💻 Desenvolvido por
Luiz Felipe Botini de Silvestro
10 anos de experiência em setores administrativos/financeiros + 3 como programador
Graduado em Ciência da Computação pela UNESC
Contato/whats: (48) 98841-7522 