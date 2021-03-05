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
    public class TempoExameSeed
    {
        public static void Seed(ProjectoBaseDataContext context)
        {
            context.TempoExames.AddOrUpdate(x => x.Descricao,
                new TempoExame() { Descricao = "30min", Ativo = true },
                new TempoExame() { Descricao = "1h", Ativo = true },
                new TempoExame() { Descricao = "1h30min", Ativo = true });


            context.SaveChanges();
        }
    }
}
