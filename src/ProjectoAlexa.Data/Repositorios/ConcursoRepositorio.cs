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
    public class ConcursoRepositorio
    {
        public static List<Concurso> RecuperarLista(string filtro = "", string ordem = "")
        {
            var ret = new List<Concurso>();

            using (var db = new ProjectoBaseDataContext())
            {
         
                ret = db.Concursos
                        .ToList();
            }

            return ret;
        }

        public static object BuscarPeloId()
        {
            throw new NotImplementedException();
        }

        public static string Salvar(Concurso concurso)
        {
            var ret = string.Empty;

            var model = BuscarPeloId(concurso.Id);

            using (var db = new ProjectoBaseDataContext())
            {
                if (model == null)
                {
                    db.Concursos.Add(concurso);
                }
                else
                {
                    db.Concursos.Attach(concurso);
                    db.Entry(concurso).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = concurso.Id;
            }

            return ret;
        }

        public static Concurso BuscarPeloId(string id)
        {
            Concurso ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Concursos.Find(id);
            }

            return ret;
        }

        public static bool ExcluirPeloId(string id)
        {
            var ret = false;

            if (id != null)
            {
                using (var db = new ProjectoBaseDataContext())
                {
                    var concurso = BuscarPeloId(id);
                    db.Concursos.Remove(concurso);
                    db.SaveChanges();
                    ret = true;
                }
            }

            return ret;
        }
    }
}
