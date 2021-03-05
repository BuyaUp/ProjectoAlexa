namespace ProjectoAlexa.Data.Migrations
{
    using ProjectoAlexa.Data.Seeds;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectoAlexa.Data.DataContexts.ProjectoBaseDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProjectoAlexa.Data.DataContexts.ProjectoBaseDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            UsuarioPerfilSeed.Seed(context);
            UsuarioSeed.Seed(context);
            ProvinciaSeed.Seed(context);
            AreaSeed.Seed(context);
            TempoExameSeed.Seed(context);
        }
    }
}
