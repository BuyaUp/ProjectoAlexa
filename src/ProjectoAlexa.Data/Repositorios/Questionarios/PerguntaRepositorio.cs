using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System.Data.Entity;
using System.Linq;

namespace ProjectoAlexa.Data.Repositorios.Questionarios
{
    public class PerguntaRepositorio
    {
        public static int Salvar(Pergunta pergunta)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                if (pergunta.Id <= 0)
                {
                    db.Perguntas.Add(pergunta);
                }
                else
                {
                    var model = BuscarPeloId(pergunta.Id).Respostas.ToList();
                    model.ForEach(p => p.Pergunta = null);
                    if (model.Any())
                    {
                        foreach (var item in model)
                            db.Entry(item).State = EntityState.Modified;

                        db.Respostas.RemoveRange(model);
                    }

                    db.Respostas.AddRange(pergunta.Respostas);
                    pergunta.Respostas = null;

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
                ret = db.Perguntas.Include(r => r.Respostas)
                        .Where(p => p.Id == id)
                        .AsNoTracking()
                        .FirstOrDefault();
            }

            return ret;
        }

        public static bool Eliminar(Pergunta pergunta)
        {
            if (pergunta != null)
            {
                using (var db = new ProjectoBaseDataContext())
                {
                    if (pergunta.Respostas.Any())
                    {
                        foreach (var item in pergunta.Respostas)
                            db.Entry(item).State = EntityState.Modified;

                        db.Respostas.RemoveRange(pergunta.Respostas);
                    }

                    db.Perguntas.Remove(pergunta);
                    db.SaveChanges();
                }
                return true;
            }

            return false;
        }

        public static bool EliminarPorId(int id)
        {
            var pergunta = BuscarPeloId(id);

            if (pergunta != null && !pergunta.Respostas.Any())
            {
                using (var db = new ProjectoBaseDataContext())
                {
                    db.Perguntas.Remove(pergunta);
                    db.SaveChanges();
                }
                return true;
            }

            return false;
        }
    }
}
