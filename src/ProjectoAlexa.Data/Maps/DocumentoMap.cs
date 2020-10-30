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
    public class DocumentoMap : EntityTypeConfiguration<Documento>
    {
        public DocumentoMap()
        {
            //Tabela
            ToTable(nameof(Documento));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("DocumentoId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }
    }
}
