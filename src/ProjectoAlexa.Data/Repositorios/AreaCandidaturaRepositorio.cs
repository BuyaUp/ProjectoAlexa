using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Repositorios
{
    public class AreaCandidaturaRepositorio
    {
        public static AreaCandidatura BuscarPeloId(int? id)
        {
            AreaCandidatura ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.AreaCandidaturas.Find(id);
            }

            return ret;
        }


        public static List<AreaCandidatura> BuscarTodas()
        {
            List<AreaCandidatura> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.AreaCandidaturas.ToList();
            }

            return ret;
        }


        public static int Salvar(AreaCandidatura area)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(area.Id);

                if (model == null)
                {
                    db.AreaCandidaturas.Add(area);
                }
                else
                {

                    db.Entry(area).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = area.Id;

            }
            return ret;
        }
    }
}
