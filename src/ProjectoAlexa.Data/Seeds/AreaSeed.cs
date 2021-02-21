using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Seeds
{
    public class AreaSeed
    {
        public static void Seed(ProjectoBaseDataContext context)
        {
            context.AreaCandidaturas.AddOrUpdate(x => x.AreaNome,
                new AreaCandidatura() { AreaNome = "Tecnologias de Informação", Ativo = true },
                new AreaCandidatura() { AreaNome = "Auxiliar de Limpeza", Ativo = true },
                new AreaCandidatura() { AreaNome = "Recursos Humanos", Ativo = true });


            context.SaveChanges();
        }
    }
}
