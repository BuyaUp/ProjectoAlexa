using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class ConcursoMap : EntityTypeConfiguration<Concurso>
    {
        public ConcursoMap()
        {
            //Tabela
            ToTable(nameof(Concurso));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasColumnName("ConcursoId");


        }
    }
}
