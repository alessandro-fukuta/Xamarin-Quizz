using MySqlConnector;
using System.Collections.Generic;
using xTCC_Questoes.Model;

namespace xTCC_Questoes
{
	public class XamarinQuiz : Conexao
	{
		public string Id { get; set; }
		public string Question { get; set; }
		public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
		public int CorrectAnswer { get; set; }
        public List<XamarinQuiz> lQuestions = new List<XamarinQuiz>();

        public bool CarregaQuestoes()
        {
            if (!Abre_Conexao())
            {
                ret= false;
                return ret;
            }
            lQuestions.Clear();
            StrQuery = "SELECT * FROM xamarinquiz ORDER BY Id";
            using (MySqlCommand cmd = new MySqlCommand(StrQuery, conn))
            {
                cmd.CommandType=System.Data.CommandType.Text;
                Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    lQuestions.Add(new XamarinQuiz
                    {
                        Id = Dr["Id"].ToString(),
                        Question = Dr["question"].ToString(),
                        Answer1 = Dr["answer1"].ToString(),
                        Answer2 = Dr["answer2"].ToString(),
                        Answer3 = Dr["answer3"].ToString(),
                        CorrectAnswer = int.Parse(Dr["correctanswer"].ToString())

                    });
                }
            }


                return ret;
        }

    }

}
