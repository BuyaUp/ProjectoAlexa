using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Repositorios.Questionarios
{
    public class QuestionarioRepositorio
    {
        public static Questionario BuscarPeloId(int? id)
        {
            Questionario ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Questionarios.Find(id);
            }

            return ret;
        }


        public static List<Questionario> BuscarTodos()
        {
            List<Questionario> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Questionarios.Include(a => a.AreaCandidatura).ToList();
            }

            return ret;
        }


        public static int Salvar(Questionario questionario)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(questionario.Id);

                if (model == null)
                {
                    db.Questionarios.Add(questionario);
                }
                else
                {

                    db.Entry(questionario).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = questionario.Id;

            }
            return ret;
        }
    }
}
