using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Repositorios
{
    public class ProvinciaRepositorio
    {
        public static List<Provincia> BuscarTodas()
        {
            List<Provincia> ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Provincias.ToList();
            }

            return ret;
        }

        public static Provincia BuscarPeloId(int id)
        {
            Provincia ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Provincias.Find(id);
            }

            return ret;
        }

    }
}
