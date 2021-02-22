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
    public class PerguntaRepositorio
    {
        public static int Salvar(Pergunta pergunta)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(pergunta.Id);

                if (model == null)
                {
                    db.Perguntas.Add(pergunta);
                }
                else
                {

                    db.Entry(pergunta).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = pergunta.Id;

            }
            return ret;
        }

        public static Pergunta BuscarPeloId(int? id)
        {
            Pergunta ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Perguntas.Find(id);
            }

            return ret;
        }

    }
}
