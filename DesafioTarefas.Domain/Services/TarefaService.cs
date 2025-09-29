using DesafioTarefas.Application.DTOs.Requests;
using DesafioTarefas.Application.DTOs.Responses;
using DesafioTarefas.Domain.Entities;
using DesafioTarefas.Domain.Enums;
using DesafioTarefas.Domain.Interfaces.Repositories;
using DesafioTarefas.Domain.Interfaces.Services;

namespace DesafioTarefas.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository=tarefaRepository;            
        }

        public TarefaResponse CriarTarefa(CriarTarefaRequest dto)
        {

            var tarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = StatusTarefa.Pendente
            };

            _tarefaRepository.Adicionar(tarefa);
            _tarefaRepository.SaveChanges();

            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };

            return response;
        }
        public TarefaResponse AtualizarTarefa(int id, CriarTarefaRequest request)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);
            if(tarefa == null)
            {
                throw new Exception($"Tarefa com ID {id} não encontrada.");
            }

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;

            return new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };                        
        }

        public void AlterarStatus(int id, StatusTarefa novoStatus)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);

            if(tarefa == null)
                {
                throw new Exception($"Tarefa com ID {id} não encontrada.");
            }

            tarefa.Status = novoStatus;

            _tarefaRepository.Atualizar(tarefa);
            _tarefaRepository.SaveChanges();

        }

        public void ExcluirTarefa(int id)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);
            if(tarefa == null)
            {
                throw new Exception($"Tarefa com ID {id} não encontrada.");
            }

            _tarefaRepository.Remover(tarefa);
            _tarefaRepository.SaveChanges();

        }

        public TarefaResponse? ObterPorId(int id)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);
            if (tarefa == null)
            {
                return null;
            }

            return new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };
        }

        public List<TarefaResponse> ObterTodas()
        {
            var tarefas = _tarefaRepository.ObterTodas();

            return tarefas.Select(tarefa => new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            }).ToList();
        }
    }
}
