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
    public class CandidaturaRepositorio
    {
        public static List<Candidatura> RecuperarLista(string filtro = "", string ordem = "")
        {
            var ret = new List<Candidatura>();

            using (var db = new ProjectoBaseDataContext())
            {
                var filtroWhere = "";
                if (!string.IsNullOrEmpty(filtro))
                {
                    filtroWhere = string.Format("where (lower(DocumentosId) like '%{0}%') ", filtro.ToLower());
                }

                var sql =
                    "select * from Candidatura " +
                    filtroWhere +
                    "order by " + (!string.IsNullOrEmpty(ordem) ? ordem : "DocumentosId");

                //ret = db.Database.Connection.Query<Candidatura>(sql).ToList();
                ret = db.Candidaturas.SqlQuery(sql).ToList();
            }

            return ret;
        }

        public static string Salvar(Candidatura candidatura)
        {
            var ret = string.Empty;

            var model = BuscarPeloId(candidatura.Id);

            using (var db = new ProjectoBaseDataContext())
            {
                if (model == null)
                {
                    db.Candidaturas.Add(candidatura);
                }
                else
                {
                    db.Candidaturas.Attach(candidatura);
                    db.Entry(candidatura).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = candidatura.Id;
            }

            return ret;
        }

        public static Candidatura BuscarPeloId(string id)
        {
            Candidatura ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Candidaturas.Find(id);
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
                    var candidatura = BuscarPeloId(id);
                    db.Candidaturas.Remove(candidatura);
                    db.SaveChanges();
                    ret = true;
                }
            }

            return ret;
        }
    }
}
