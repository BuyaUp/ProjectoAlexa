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
    public class AreaCandidaturaMap : EntityTypeConfiguration<AreaCandidatura>
    {
        public AreaCandidaturaMap()
        {
            //Tabela
            ToTable(nameof(AreaCandidatura));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnName("AreaCandidaturaId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
