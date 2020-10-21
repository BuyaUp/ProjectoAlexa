using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.DataContexts
{
    public class ProjectoBaseDataContext : DbContext
    {

        public ProjectoBaseDataContext() : base("ProjectoAlexaConnectString") // base permite acessar o construtor do DbContext
        {
            Database.SetInitializer(new DbInitializer()); //define a criação e alteração da base de dados
        }

        //Objectos a serem mapeado para uma colecção e criacao
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //Criar BD usando fluent API
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioPerfilMap());
        }
    }
}
