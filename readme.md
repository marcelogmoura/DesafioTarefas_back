# 💻 DesafioTarefas - Gerenciador de Tarefas (CRUD)

Este projeto é uma **API RESTful** desenvolvida em **ASP.NET Core** para gerenciar tarefas, seguindo os princípios de **Clean Architecture** (Arquitetura Limpa) e Domain-Driven Design (DDD).

---

## 📋 Requisitos e Documentação

Os requisitos completos do teste técnico (prova) estão detalhados no documento oficial:
* **[01. Prova .pdf](https://github.com/marcelogmoura/DesafioTarefas_back/blob/main/Pdf/01.%20Prova%20.pdf)**

### Funcionalidades (CRUD)

A API implementa o ciclo completo de gerenciamento de tarefas:

* **Criar (Create):** Endpoint `POST /api/tarefas`
* **Consultar (Read):** Endpoints `GET /api/tarefas` e `GET /api/tarefas/{id}`
* **Atualizar (Update):** Endpoint `PUT /api/tarefas/{id}`
* **Excluir (Delete):** Endpoint `DELETE /api/tarefas/{id}`

Cada tarefa possui os campos: **ID** (GUID, gerado automaticamente), **Título**, **Descrição**, e **Status** (`Pendente`/`Concluída`).

### Especificação da API (Swagger/Scalar)

A documentação interativa da API está disponível em ambiente de desenvolvimento (porta 5046).

* **URL da Documentação (Swagger/Scalar):** `http://localhost:5046/swagger`

---

## 🛠️ Tecnologias e Arquitetura

* **Linguagem:** C# e .NET 9.0 (ASP.NET Core)
* **Base de Dados:** SQL Server (configurado via Docker)
* **ORM:** Entity Framework Core
* **Padrões:** Clean Architecture / DDD
* **Ferramentas:** Docker, Git, Visual Studio 2022 Community

### Estrutura do Projeto

A solução segue a arquitetura em camadas (Clean Architecture):

| Camada | Descrição |
| :--- | :--- |
| **DesafioTarefas.API** | Camada de apresentação (Controllers) e configuração da Injeção de Dependência. |
| **DesafioTarefas.Domain** | Contém o **Domínio** (regras de negócio, Interfaces de Serviço e Repositório). |
| **DesafioTarefas.Infrastructure** | Contém a **Infraestrutura** (implementação dos Repositórios e do `DbContext`). |

---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para subir a API localmente via Docker.

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

* [.NET SDK 9.0 ou superior](https://dotnet.microsoft.com/download)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) (em execução)
* [Git e Git Bash](https://git-scm.com/downloads) (ou terminal de sua preferência)
* [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/community/) (para abrir e editar a solução)

### 1. Clonar o Repositório

```bash
git clone git@github.com:marcelogmoura/DesafioTarefas_back.git
cd DesafioTarefas