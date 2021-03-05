using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class ExameMap:EntityTypeConfiguration<Exame>
    {
        public ExameMap()
        {
            //Tabela
            ToTable(nameof(Exame));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("ExameId");

            // Relacionamentos
            HasRequired(prod => prod.Candidatura) //tabela primária ou PK
                .WithMany(tipo => tipo.Exames) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.CandidaturaId);

            HasRequired(prod => prod.Questionario) //tabela primária ou PK
                .WithMany(tipo => tipo.Exames) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.QuestionarioId);

        }
    }
}
