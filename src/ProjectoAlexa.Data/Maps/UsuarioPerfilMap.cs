using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasColumnAnnotation( //Cria o indice do campo email
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UQ_dbo.UsuarioPerfil.PerfilNome") { IsUnique = true })
                );

            Property(col => col.DataCadastro);
            Property(col => col.Ativo);
        }
    }
}
