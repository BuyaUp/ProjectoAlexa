using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class ProvaMap : EntityTypeConfiguration<Prova>
    {
        public ProvaMap()
        {
            //Tabela
            ToTable(nameof(Prova));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasColumnName("ProvaId");

            // Relacionamentos
            HasRequired(prod => prod.Exame) //tabela primária ou PK
                .WithMany(tipo => tipo.Provas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.ExameId);

            HasRequired(prod => prod.Pergunta) //tabela primária ou PK
                .WithMany(tipo => tipo.Provas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.PerguntaId);

            HasRequired(prod => prod.Resposta) //tabela primária ou PK
                .WithMany(tipo => tipo.Provas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.RespostaSelecionadaId);
        }
    }
}
