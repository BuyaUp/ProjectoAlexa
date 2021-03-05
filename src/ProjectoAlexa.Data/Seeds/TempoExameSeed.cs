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
                new TempoExame() { Descricao = "30min", ValorMinuto = 30, Ativo = true },
                new TempoExame() { Descricao = "1h", ValorMinuto = 60, Ativo = true },
                new TempoExame() { Descricao = "1h30min", ValorMinuto = 90, Ativo = true },
                new TempoExame() { Descricao = "2h", ValorMinuto = 90, Ativo = true });

            context.SaveChanges();
        }
    }
}
