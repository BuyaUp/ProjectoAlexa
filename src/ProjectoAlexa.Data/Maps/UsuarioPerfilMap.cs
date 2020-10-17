using ProjectoAlexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Maps
{
    public class UsuarioPerfilMap : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilMap()
        {
            //Tabela
            ToTable(nameof(UsuarioPerfil));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(col => col.PerfilNome)
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();

            Property(col => col.DataCadastro);
            Property(col => col.Ativo);
        }
    }
}
