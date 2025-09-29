using DesafioTarefas.Application.DTOs.Requests;
using DesafioTarefas.Application.DTOs.Responses;
using DesafioTarefas.Domain.Enums;

namespace DesafioTarefas.Domain.Interfaces.Services
{
    public interface ITarefaService
    {
        TarefaResponse CriarTarefa(CriarTarefaRequest dto);
        List<TarefaResponse> ObterTodas();
        TarefaResponse? ObterPorId(int id);
        TarefaResponse AtualizarTarefa(int id, CriarTarefaRequest request);         
        void AlterarStatus(int id, StatusTarefa novoStatus);        
        void ExcluirTarefa(int id);
    }
}
