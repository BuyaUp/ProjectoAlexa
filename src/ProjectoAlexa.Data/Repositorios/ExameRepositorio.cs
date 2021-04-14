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
    public class ExameRepositorio
    {
        public static Exame BuscarPeloId(string id)
        {
            Exame ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Exames.Find(id);
            }

            return ret;
        }


        public static List<Exame> BuscarTodos()
        {
            List<Exame> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Exames.ToList();
            }

            return ret;
        }


        public static string Salvar(Exame exame)
        {
            var ret = "";

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(exame.Id);

                if (model == null)
                {
                    db.Exames.Add(exame);
                }
                else
                {

                    db.Entry(exame).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = exame.Id;

            }
            return ret;
        }
    }
}
