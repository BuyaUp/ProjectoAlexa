using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Seeds
{
    public class ProvinciaSeed
    {
        public static void Seed(ProjectoBaseDataContext context)
        {

            #region Provincias

            context.Provincias.AddOrUpdate(x => x.ProvinciaNome,
                new Provincia() { ProvinciaNome = "Luanda"},
                new Provincia() { ProvinciaNome = "Bengo"},
                new Provincia() { ProvinciaNome = "Benguela"},
                new Provincia() { ProvinciaNome = "Bié"},
                new Provincia() { ProvinciaNome = "Cabinda"},
                new Provincia() { ProvinciaNome = "Cuando Cubango"},
                new Provincia() { ProvinciaNome = "Cuanza Norte"},
                new Provincia() { ProvinciaNome = "Cuanza Sul"},
                new Provincia() { ProvinciaNome = "Cunene"},
                new Provincia() { ProvinciaNome = "Huambo"},
                new Provincia() { ProvinciaNome = "Huíla"},
                new Provincia() { ProvinciaNome = "Lunda Norte"},
                new Provincia() { ProvinciaNome = "Lunda Sul"},
                new Provincia() { ProvinciaNome = "Malanje"},
                new Provincia() { ProvinciaNome = "Moxico"},
                new Provincia() { ProvinciaNome = "Namibe"},
                new Provincia() { ProvinciaNome = "Uíge"},
                new Provincia() { ProvinciaNome = "Zaire"}
                );

            #endregion

            context.SaveChanges();

          
        }
    }
}
