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
    public class PerguntaMap : EntityTypeConfiguration<Pergunta>
    {
        public PerguntaMap()
        {
            //Tabela
            ToTable(nameof(Pergunta));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnName("PerguntaId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");

            //Relacionamentos
            HasRequired(prod => prod.Questionario) //tabela primária ou PK
                .WithMany(tipo => tipo.Perguntas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.QuestionarioId); // chave estrangeira
        }
    }
}
