using System.ComponentModel.DataAnnotations;

namespace CPA_Project.Areas.AlunoArea.Models
{
    public class Alunos
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CodigoAluno { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigratório")]
        public string Senha { get; set; }

        public string CodigoTurma { get; set; }
    }
}