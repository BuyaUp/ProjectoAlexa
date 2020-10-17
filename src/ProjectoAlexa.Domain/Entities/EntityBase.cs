using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Domain.Entities
{
    public class EntityBase<TEntity>
    {
        public EntityBase()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
        }


        public TEntity Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
