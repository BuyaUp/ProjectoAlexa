﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Concurso : Entity<string>
    {
        public Concurso()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataExames { get; set; }
        public DateTime DataResultados { get; set; }

        public virtual ICollection<Candidatura> Candidaturas { get; set; }
    }
}
