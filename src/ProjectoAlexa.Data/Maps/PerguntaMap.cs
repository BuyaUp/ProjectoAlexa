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

            //Relacionamentos
            HasRequired(prod => prod.AreaCandidatura) //tabela primária ou PK
                .WithMany(tipo => tipo.Perguntas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.AreaCandidaturaId); // chave estrangeira

            HasRequired(prod => prod.Usuario) //tabela primária ou PK
               .WithMany(tipo => tipo.Perguntas) //tabela secundária ou que recebe a FK
               .HasForeignKey(fk => fk.UsuarioId); // chave estrangeira
        }
    }
}
