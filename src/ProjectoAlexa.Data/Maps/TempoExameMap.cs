using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class TempoExameMap : EntityTypeConfiguration<TempoExame>
    {
        public TempoExameMap()
        {
            //Tabela
            ToTable(nameof(TempoExame));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasColumnName("TempoExameId");


        }
    }
}
