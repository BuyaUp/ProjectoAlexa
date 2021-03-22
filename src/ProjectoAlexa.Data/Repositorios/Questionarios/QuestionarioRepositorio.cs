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
                ret = db.Questionarios.Include(p => p.Perguntas.Select(r => r.Respostas))
                     .Where(q => q.Id == id)
                     .AsNoTracking()
                     .FirstOrDefault();
            }

            return ret;
        }

        public static List<Questionario> BuscarTodos()
        {
            List<Questionario> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Questionarios
                     .Include(a => a.AreaCandidatura)
                     .Include(a => a.Perguntas.Select(r => r.Respostas))
                     .AsNoTracking()
                     .OrderByDescending(q => q.DataCadastro)
                     .ToList();
            }

            return ret;
        }

        public static List<Questionario> BuscarPorNome(string titulo)
        {
            return BuscarTodos()
                 .Where(q => q.Titulo.ToLower().Contains(titulo.ToLower()))
                 .ToList();
        }

        public static string GerarNomeAutomatico()
        {
            int max = 1;
            List<Questionario> quiz = BuscarPorNome("Question");

            if (quiz != null)
            {
                foreach (var item in quiz)
                {
                    var verificaNome = item.Titulo.Split(' ');

                    for (int i = 0; i < verificaNome.Length; i++)
                    {
                        if (int.TryParse(verificaNome[i], out int result))
                            if (result >= max)
                                max = result + 1;
                    }
                }

                return $"Questionário {max}";
            }
            else
                return $"Questionário {max}";
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
