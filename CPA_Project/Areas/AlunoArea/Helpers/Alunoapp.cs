using System.Collections.Generic;
using System.Data.SqlClient;
using CPA_Project.Areas.AlunoArea.Models;
using CPA_Project.Connect_DB;

namespace CPA_Project.Areas.AlunoArea.Helpers
{
    public class Alunoapp
    {
        private Contexto _contexto;

        public List<Alunos> Alunos()
        {
            using (_contexto = new Contexto())
            {
                const string strQuery = "SELECT * FROM ALUNOS";
                var dadosAluno = _contexto.ComandoDataReader(strQuery);
                return ConverterDataReaderToList(dadosAluno);
            }

        }

        private List<Alunos> ConverterDataReaderToList(SqlDataReader reader)
        {
            var aluno = new List<Alunos>();
            while (reader.Read())
            {
                var tempAluno = new Alunos()
                {
                    CodigoAluno = reader["CodigoAluno"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Senha = reader["Senha"].ToString(),
                    CodigoTurma = reader["CodigoTurma"].ToString()
                };

                aluno.Add(tempAluno);
            }

            reader.Close();
            return aluno;
        } 
    }
} 