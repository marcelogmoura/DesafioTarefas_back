using DesafioTarefas.Domain.Entities;

namespace DesafioTarefas.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {       
        void Adicionar(Tarefa tarefa);     
        Tarefa? ObterPorId(int id);
        List<Tarefa> ObterTodas();     
        void Atualizar(Tarefa tarefa);     
        void Remover(Tarefa tarefa);
        int SaveChanges();
    }
}