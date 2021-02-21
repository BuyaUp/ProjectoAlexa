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
    public class CandidaturaMap : EntityTypeConfiguration<Candidatura>
    {
        public CandidaturaMap()
        {
            //Tabela
            ToTable(nameof(Candidatura));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("CandidaturaId");

            // Relacionamentos
            HasRequired(prod => prod.AreaCandidatura) //tabela primária ou PK
                .WithMany(tipo => tipo.Candidaturas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.AreaCandidaturaId);

            HasRequired(prod => prod.Usuario) //tabela primária ou PK
                .WithMany(tipo => tipo.Candidaturas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.UsuarioId);

            HasRequired(prod => prod.Provincia) //tabela primária ou PK
                .WithMany(tipo => tipo.Candidaturas) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.ProvinciaId);
        }
    }
}
