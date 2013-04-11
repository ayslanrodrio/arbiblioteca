using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARBiblioteca.Dominio
{
    public class Livro
    {
        [Required(ErrorMessage = "Preencha o campo Código!")]
        [Display(Name = "Código")]
        public int CodLivro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título!")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Autor!")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ano!")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "Preencha o campo Editora!")]
        public string Editora { get; set; }

    }
}
