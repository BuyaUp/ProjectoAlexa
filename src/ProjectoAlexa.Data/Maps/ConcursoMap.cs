using ProjectoAlexa.Data.Entities;
using System.Data.Entity.ModelConfiguration;

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
