using DesafioTarefas.Domain.Enums;

namespace DesafioTarefas.Application.DTOs.Responses
{
    public class TarefaResponse
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }

}