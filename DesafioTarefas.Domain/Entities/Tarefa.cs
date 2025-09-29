using DesafioTarefas.Domain.Enums;

namespace DesafioTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get;  set; }
        public string? Titulo { get;  set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }  

    }
}