using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.Models
{
    public class UsuarioPerfilModel
    {
        #region Atributos

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual List<UsuarioModel> Usuarios { get; set; }

        #endregion


    }
}
