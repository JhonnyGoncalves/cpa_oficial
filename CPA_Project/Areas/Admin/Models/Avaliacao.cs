using System;
using System.Reflection;

namespace CPA_Project.Areas.Admin.Models
{
    public class Avaliacao
    {
        public int Avaliacao_id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_expedicao { get; set; }

    }
}