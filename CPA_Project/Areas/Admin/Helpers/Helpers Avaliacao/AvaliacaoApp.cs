using System;
using CPA_Project.Areas.Admin.Controllers;
using CPA_Project.Areas.Admin.Models;
using CPA_Project.Connect_DB;

namespace CPA_Project.Areas.Admin.Helpers
{
    public class AvaliacaoApp
    {
        private Contexto _contexto;

        public void criarAvaliacao(Avaliacao avaliacao) // Criando avaliacao e pegando o id dela;
        {
            var strQuery = string.Format("INSERT INTO AVALIACAO(NOME, DATA_CRIACAO, DATA_EXPEDICAO) VALUES('{0}','{1}','{2}')",
                avaliacao.Nome, avaliacao.Data_criacao, avaliacao.Data_expedicao);

            using (_contexto = new Contexto())
            {
               var id = _contexto.ComandoNonQueryINSERT(strQuery);
                id = 2;
            }
        }

        public void criarAvaliacaoComQuestao(int idQuestao , int idAvaliacao)
        {
            var strQuery = string.Format("INSERT INTO AVALIACAO_QUESTAO(AVALIACAO_ID, QUESTAO_ID) VALUES('{0}','{1}')", idAvaliacao, idQuestao);
        }
    }
}