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
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable(nameof(Usuario));

            //PK
            HasKey(pk => pk.Id);

            //Colunas
            Property(col => col.Id)
                .HasColumnType("varchar")
                .HasColumnName("UsuarioId");
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(col => col.NomeUsuario)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(col => col.Email)
                .HasColumnType("varchar")
                .HasMaxLength(254)
                .IsRequired()
                .HasColumnAnnotation( //Cria o indice do campo email
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UQ_dbo.Usuario.Email") { IsUnique = true })
                );

            Property(col => col.Senha)
                .HasColumnType("char")
                .HasMaxLength(88)
                .IsRequired();

            Property(col => col.DataCadastro);
            Property(col => col.Ativo);

            //Relacionamentos
            HasRequired(prod => prod.UsuarioPerfil) //tabela primária ou PK
                .WithMany(tipo => tipo.Usuarios) //tabela secundária ou que recebe a FK
                .HasForeignKey(fk => fk.UsuarioPerfilId); // chave estrangeira
        }
    }
}
