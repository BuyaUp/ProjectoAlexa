using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class RespostaMap : EntityTypeConfiguration<Resposta>
    {
        public RespostaMap()
        {
            //Tabela
            ToTable(nameof(Resposta));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnName("RespostaId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(col => col.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(col => col.PerguntaId)
                .IsRequired();

            //Relacionamentos 
            HasRequired(p => p.Pergunta)
                .WithMany(p => p.Respostas)
                .HasForeignKey(fk => fk.PerguntaId);
        }
    }
}
