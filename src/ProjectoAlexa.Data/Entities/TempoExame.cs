﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class TempoExame : Entity<string>
    {
        public TempoExame()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Descricao { get; set; }
        public DateTime Valor { get; set; }

        public virtual ICollection<Questionario> Questionarios { get; set; }
    }
}
