using DesafioTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTarefas.Infrastructure.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TB_Tarefas"); 

            builder.HasKey(t => t.Id);  

            builder.Property(t => t.Titulo)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(500);
                        
            builder.Property(t => t.Status)
                .HasColumnName("Status") 
                .HasConversion<int>()    
                .IsRequired();
        }
    }
}
