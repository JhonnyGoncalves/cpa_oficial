using System.Web.Mvc;
using CPA_Project.Areas.AlunoArea.Models;

namespace CPA_Project.Areas.AlunoArea.Controllers
{
    // Incluir o identity neste trecho de codigo, junto com o retorno de dados do aluno
    public class AlunoController : Controller
    {
        public ActionResult Index(Alunos aluno)
        {
            return View(aluno);
        }
	}
}