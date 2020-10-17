﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Domain.Entities
{
    public class Provincia : EntityBase<string>
    {
        public Provincia()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string ProvinciaNome { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
