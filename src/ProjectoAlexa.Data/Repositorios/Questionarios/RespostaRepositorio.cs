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
    public class RespostaRepositorio
    {
        public static int Salvar(Resposta resposta)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = BuscarPeloId(resposta.Id);

                if (model == null)
                {
                    db.Respostas.Add(resposta);
                }
                else
                {

                    db.Entry(resposta).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = resposta.Id;

            }
            return ret;
        }

        public static Resposta BuscarPeloId(int? id)
        {
            Resposta ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Respostas
                        .Where(p => p.Id.Equals(id))
                        .FirstOrDefault();
            }

            return ret;
        }

        public static bool Eliminar(int id)
        {
            var resp = BuscarPeloId(id);

            if (resp != null && !resp.RespostaCerta)
            {
                return false;
            }

            return true;
        }
    }
}
