using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using CPA_Project.Areas.AlunoArea.Helpers;
using CPA_Project.Areas.AlunoArea.Models;
using CPA_Project.Connect_DB;

namespace CPA_Project.Areas.AlunoArea.Controllers
{
    // Incluir o identity neste trecho de codigo, junto com o retorno de dados do aluno
    public class AlunoController : Controller
    {
        public static Contexto Contexto = new Contexto();

        public readonly AvaliacaoApp Avaliacao = new AvaliacaoApp(Contexto);

        public ActionResult Index()
        {
            return View(Avaliacao.Questao());
        }
        public ActionResult Sair()
        {
            var ctx = Request.GetOwinContext();
            var auth = ctx.Authentication;
            auth.SignOut();
            return Redirect("/Home/Index");
        }
	}
}