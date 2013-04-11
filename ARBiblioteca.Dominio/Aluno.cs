using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARBiblioteca.Dominio
{
    public class Aluno
    {
        public int CodAluno { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Dada de Nascimento!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome da Mãe!")]
        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço!")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone!")]
        public string Telefone { get; set; }
    }
}
