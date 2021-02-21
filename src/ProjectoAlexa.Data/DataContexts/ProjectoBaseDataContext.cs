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

            //Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //Objectos a serem mapeado para uma colecção e criacao
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfis { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Candidatura> Candidaturas { get; set; }
        public DbSet<AreaCandidatura> AreaCandidaturas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //Criar BD usando fluent API
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Toda a propriedade de uma tabela do tipo "string" será criada como "varchar" no banco de dados
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            /*
             * Toda a propriedade de uma tabela do tipo "string" terá por padrão o tamanho máximo de 100 carecteres
             * Caso não for definida              
            */
            //modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioPerfilMap());

            modelBuilder.Configurations.Add(new Maps.AreaCandidaturaMap());
            modelBuilder.Configurations.Add(new Maps.CandidaturaMap());

            modelBuilder.Configurations.Add(new Maps.PerguntaMap());
            modelBuilder.Configurations.Add(new Maps.RespostaMap());
            modelBuilder.Configurations.Add(new Maps.QuestionarioMap());

            modelBuilder.Configurations.Add(new Maps.ProvinciaMap());
        }
    }
}
