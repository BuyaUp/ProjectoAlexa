using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Entity<TEntity>
    {
        public TEntity Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public Entity()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

    }
}
