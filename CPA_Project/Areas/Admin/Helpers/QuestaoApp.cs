using System.Collections.Generic;
using System.Data.SqlClient;
using CPA_Project.Areas.AlunoArea.Models;
using CPA_Project.Connect_DB;

namespace CPA_Project.Areas.Admin.Helpers
{
    public class QuestaoApp
    {
        private Contexto _contexto;

        public QuestaoApp(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Questao> Questao()
        {
            using (_contexto = new Contexto())
            {
                const string strQuery = "SELECT * FROM QUESTAO";
                var dados = _contexto.ComandoDataReader(strQuery);
                return ConverterDataReaderToList(dados);
            }

        }

        private List<Questao> ConverterDataReaderToList(SqlDataReader reader)
        {
            var questao = new List<Questao>();
            while (reader.Read())
            {
                var tempQuestao = new Questao()
                {
                   QuestaoId = int.Parse(reader["Questao_id"].ToString()),
                   Descricao = reader["Descricao"].ToString()
                };

                questao.Add(tempQuestao);
            }

            reader.Close();
            return questao;
        }
    }
}
