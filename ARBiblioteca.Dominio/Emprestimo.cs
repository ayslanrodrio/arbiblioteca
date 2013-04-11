using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARBiblioteca.Dominio
{
    public class Emprestimo
    {
        public int CodEmprestimo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código do aluno!")]
        [Display(Name = "Código do Aluno")]
        public int CodAluno { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código do Livro!")]
        [Display(Name = "Código do Livro")]
        public int CodLivro { get; set; }

        [Display(Name = "Data do Emmpréstimo")]
        public string DataEmprestimo { get; set; }

        [Display(Name = "Data da Devolução")]
        public string DataDevolucao { get; set; }
    }
}
