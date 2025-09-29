using DesafioTarefas.Application.DTOs.Requests;
using DesafioTarefas.Domain.Entities;
using DesafioTarefas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService=tarefaService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CriarTarefaRequest tarefa)
        {
            try
            {
                var response = _tarefaService.CriarTarefa(tarefa);
                return StatusCode(201, tarefa);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao criar a tarefa.", detalhes = ex.Message });

            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var tarefa = _tarefaService.ObterPorId(id);
                if (tarefa == null)
                {
                    return NotFound(new { mensagem = "Tarefa não encontrada." });
                }
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao obter a tarefa.", detalhes = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            try
            {
                var tarefas = _tarefaService.ObterTodas();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao obter as tarefas.", detalhes = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] CriarTarefaRequest request)
        {
            try
            {
                var tarefaAtualizada = _tarefaService.AtualizarTarefa(id, request);
                return Ok(tarefaAtualizada);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { mensagem = "Tarefa não encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao atualizar a tarefa.", detalhes = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _tarefaService.ExcluirTarefa(id);
                return StatusCode(200, new { message = "Fabricante excluído com sucesso." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { mensagem = "Tarefa não encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao remover a tarefa.", detalhes = ex.Message });
            }
        }
    }
}