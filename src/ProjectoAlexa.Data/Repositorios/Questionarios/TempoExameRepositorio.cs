using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectoAlexa.Data.Repositorios.TempoExames
{
    public class TempoExameRepositorio
    {
        public static string Salvar(TempoExame tempoExame)
        {
            var ret = string.Empty;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(tempoExame.Id);

                if (model == null)
                {
                    db.TempoExames.Add(tempoExame);
                }
                else
                {

                    db.Entry(tempoExame).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = tempoExame.Id;

            }
            return ret;
        }


        public static List<TempoExame> BuscarTodos()
        {
            List<TempoExame> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.TempoExames
                     .AsNoTracking()
                     .OrderBy(t => t.ValorMinuto)
                     .ToList();
            }

            return ret;
        }

        public static TempoExame BuscarPeloId(string id)
        {
            TempoExame ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.TempoExames
                     .Where(q => q.Id == id)
                     .AsNoTracking()
                     .FirstOrDefault();
            }

            return ret;
        }
    }
}
