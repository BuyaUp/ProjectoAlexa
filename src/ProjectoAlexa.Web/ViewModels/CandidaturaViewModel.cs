using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjectoAlexa.Web.ViewModels
{
    public class CandidaturaViewModel
    {
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "Selecione o Area de candidatura.")]
        public int AreaCandidaturaId { get; set; }

        public string BI { get; set; }
        public string Certificado { get; set; }
        public string Carta { get; set; }


        [Display(Name = "Cópia de BI")]
        [Required(ErrorMessage = "Falta o BI.")]
        public HttpPostedFileBase BIFile { get; set; }

        [Display(Name = "Certificado")]
        [Required(ErrorMessage = "Falta o certificado.")]
        public HttpPostedFileBase CertificadoFile { get; set; }

        [Display(Name = "Carta p/ Ministro")]
        [Required(ErrorMessage = "Falta a carta.")]
        public HttpPostedFileBase CartaFile { get; set; }

        [Required(ErrorMessage = "Selecione a Província de candidatura.")]
        public string ProvinciaId { get; set; }

        [Required(ErrorMessage = "O campo concurso é obrigatório.")]
        public string ConcursoId { get; set; }
    }
}
