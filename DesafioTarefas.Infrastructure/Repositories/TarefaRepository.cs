using DesafioTarefas.Domain.Entities;
using DesafioTarefas.Domain.Interfaces.Repositories;
using DesafioTarefas.Infrastructure.Data;

namespace DesafioTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public TarefaRepository(ApplicationDbContext dataContext)
        {
            _dataContext=dataContext;
        }

        public void Adicionar(Tarefa tarefa)
        {
            _dataContext.Add(tarefa);
            //_dataContext.SaveChanges();
        }

        public void Atualizar(Tarefa tarefa)
        {
            _dataContext.Update(tarefa);           
        }

        public Tarefa? ObterPorId(int id)
        {
            return _dataContext.Tarefas.Find(id);
        }

        public List<Tarefa> ObterTodas()
        {
            return _dataContext.Tarefas.ToList();
        }

        public void Remover(Tarefa tarefa)
        {
            _dataContext.Remove(tarefa);            
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
    }
}
