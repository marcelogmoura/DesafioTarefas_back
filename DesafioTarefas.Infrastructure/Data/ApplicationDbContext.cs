using DesafioTarefas.Domain.Entities;
using DesafioTarefas.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioTarefas.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TarefaMapping());

        }
    }
}
