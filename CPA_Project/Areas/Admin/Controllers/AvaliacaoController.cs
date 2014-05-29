using System;
using System.Web.Mvc;
using CPA_Project.Areas.Admin.Helpers;
using CPA_Project.Areas.Admin.Models;
using System.Collections.Generic;

namespace CPA_Project.Areas.Admin.Controllers
{
    public class AvaliacaoController : Controller
    {
        private AvaliacaoApp _avaliacaoApp = new AvaliacaoApp();
        //
        // GET: /Admin/Avaliacao/
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Avaliacao avaliacao)
        {
            _avaliacaoApp.criarAvaliacao(avaliacao);
            return RedirectToAction("EscolherQuestao", avaliacao.Avaliacao_id);
        }

        public ActionResult EscolherQuestao(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult EscolherQuestao(Questao questao)
        {
            return View();
        }


	}

    public class AvaliacaoViewModel
    {
        public string Nome { get; set; }

        public DateTime Data_criacao { get; set; }

        public DateTime Data_expedicao { get; set; }
        public List<int> Questoes { get; set; }
    }
}