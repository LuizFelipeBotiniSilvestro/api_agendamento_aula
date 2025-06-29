# Sistema de Agendamento

Sistema de agendamento de aulas coletivas para academias, desenvolvido em **.NET 8** com **PostgreSQL**.

## 📚 Visão Geral

Este sistema permite:

- Cadastro de **alunos**, com plano (Mensal, Trimestral, Anual)
- Cadastro de **aulas** (Cross, Musculação, Pilates, Spinning)
- Cadastro de **agendamento de aulas** (Aula e Data)
- Cadastro de **agendamento de alunos nas aulas**
- Relatórios por aluno com total de agendamentos e aulas mais frequentadas

Fluxograma de funcionamento
Etapas:
1. Cadastro de Aula:
Ex: 
nm_aula: Pilates
tp_aula: 1 ou "cross"
nr_capacidade: 15

2. Cadastro de Aluno:
Ex: 
nm_aluno: Luiz Felipe
tp_plano: 1 ou "mensal"

3. Cadastro de Agendamento da Aula:
Ex: 
id_aula: 1 (Pilates)
dt_aula: 30/06/2025 20:00h

id_aula: 1 (Pilates)
dt_aula: 07/07/2025 20:00h

4. Cadastro de Agendamento do Aluno:
Ex: 
id_aluno: 1 (Luiz)
id_agendamento_aula: 1  (Pilates - 30/06/2025 20:00h)

id_aluno: 1 (Luiz)
id_agendamento_aula: 2  (Pilates - 07/07/2025 20:00h)

"Ou seja, sabe-se que Luiz está vinculado às aulas de Pilates toda segunda-feira 20:00h".
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
   git clone https://github.com/LuizFelipeBotiniSilvestro/api_agendamento_aula.git

2. Certifique-se de estar na pasta da API: SistemaAgendamento.Api
    Caso necessário:
    cd SistemaAgendamento.Api

3. Execute o projeto
    dotnet run

4. Acesse a documentação Swagger:
    http://localhost:5045/swagger

Observação: O banco de dados já está configurado (em ambiente de nuvem), não sendo necessária nenhuma ação adicional a esse respeito.

📌 Observações
A arquitetura é modularizada por domínio (Aluno, Aula, etc.).

O código segue boas práticas com validações, tratamento de erros e separação de responsabilidades.

Use CancellationToken em métodos assíncronos.

## 🚀 Responsável

🧑‍💻 Desenvolvido por: Luiz Felipe Botini de Silvestro
📅 Data: Jun/2025

Profissional com 10 anos de experiência em áreas administrativas e financeiras, e mais de 7 anos de atuação com programação.
Graduado em Ciência da Computação pela UNESC.

📅 Experiência profissional:

2013–2022: Atuação em setores administrativos e financeiros.

2018–2024: Ingressou na graduação em Ciência da Computação, conciliando estudos com a experiência profissional.

Desde 2022: Transição completa para a área de desenvolvimento de software, atuando como programador.

📞 Contato/WhatsApp: (48) 98841-7522