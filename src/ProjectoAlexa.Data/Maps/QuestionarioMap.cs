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
    public class QuestionarioMap:EntityTypeConfiguration<Questionario>
    {
        public QuestionarioMap()
        {
            //Tabela
            ToTable(nameof(Questionario));

            //PK
            HasKey(pk => pk.Id);


            //Colunas
            Property(col => col.Id)
                .HasColumnName("QuestionarioId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Titulo)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            Property(p => p.UsuarioId)
                .IsRequired();

            Property(p => p.AreaCandidaturaId)
                .IsRequired();

            //Relacionamentos
            HasRequired(p => p.Usuario) //tabela primária ou PK
                .WithMany(u => u.Questionarios) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.UsuarioId); //chave estrangeira

            HasRequired(p => p.AreaCandidatura) //tabela primária ou PK
                .WithMany(ac => ac.Questionarios) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.AreaCandidaturaId); //chave estrangeira

        }
    }
}
