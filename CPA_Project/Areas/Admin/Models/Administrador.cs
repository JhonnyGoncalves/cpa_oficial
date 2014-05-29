using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CPA_Project.Areas.Admin.Models
{
    public class Administrador
    {
        [Required(ErrorMessage = "Preencha o campo Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Preencha o campo Senha")]
        public string Senha { get; set; }
        public string Permissao { get; set; }

    }
}