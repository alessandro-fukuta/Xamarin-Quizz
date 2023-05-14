using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using xTCC_Questoes.Model;

using MySqlConnector;
using System.Collections;

namespace xTCC_Questoes
{
    public class QuestionViewModel: INotifyPropertyChanged
    {
        private int _correctAnswer = 0;
        public int CorrectAnswer { 
            get { return this._correctAnswer; } 
            set { 
                this._correctAnswer = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("CorrectAnswer"));
                } 
        }
        private string _question;
        public string Question {
            get { return this._question; }
            set
            {
                this._question = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Question"));
            }
        }

        private string _answer1;
        public string Answer1 {
            get { return this._answer1; }
            set
            {
                this._answer1 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer1"));
            }
        }

        private bool _answer1Enabled;
        public bool Answer1Enabled {
            get { return this._answer1Enabled; }
            set
            {
                this._answer1Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer1Enabled"));
            }
        }

        private string _answer2;
        public string Answer2 {
            get { return this._answer2; }
            set
            {
                this._answer2 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer2"));
            }
        }

        private bool _answer2Enabled;
        public bool Answer2Enabled {
            get { return this._answer2Enabled; }
            set
            {
                this._answer2Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer2Enabled"));
            }
        }

        private string _answer3;
        public string Answer3 {
            get { return this._answer3; }
            set
            {
                this._answer3 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer3"));
            }
        }

        private bool _answer3Enabled;
        public bool Answer3Enabled {
            get { return this._answer3Enabled; }
            set
            {
                this._answer3Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer3Enabled"));
            }
        }

        private List<XamarinQuiz> _questionList;
        List<XamarinQuiz> QuestionList {
            get { return this._questionList; }
            set
            {
                this._questionList = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("QuestionList"));
            }
        }
        Random rnd = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLoading;
        public bool IsLoading {
            get { return this._isLoading; }
            set
            {
                this._isLoading = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("IsLoading"));
            }
        }

        private string _message;
        public string Message
        { 
            get {
                return this._message;
            }
            set { 
                this._message = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Message"));
                } 
        }

        ArrayList ListaNumeros;
        

        public QuestionViewModel()
        {

            ListaNumeros = numerosAleatorios(0, AppSettings.QUESTIONS_COUNT, AppSettings.QUESTIONS_COUNT);

            _ = LoadQuestions();



        }

        XamarinQuiz XamQuestions = new XamarinQuiz();
        public async Task LoadQuestions()
        {
            IsLoading = true;

            XamQuestions.CarregaQuestoes();
            QuestionList = XamQuestions.lQuestions;

            IsLoading = false;
            ChooseNewQuestion();

        }


        public bool CheckIfCorrect(int correct)
        {
            if (CorrectAnswer == correct)
            {
                Message = "Acertou !";
                return true;
            }
            Message = "Errou !";
            return false;
        }

        /*
        public async Task LoadQuestions()
        {
            IsLoading = true;
            MobileServiceClient client = AppSettings.MobileService;

            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = client.GetTable<XamarinQuiz>();

            try
            {
                QuestionList = await xamarinQuizTable.ToListAsync();
            }
            catch (Exception exc)
            {
            }


            IsLoading = false;
            ChooseNewQuestion();
        }
        */

        public void ChooseNewQuestion() {
            
            IsLoading = true;
            int proximo = int.Parse(ListaNumeros[0].ToString());
            XamarinQuiz selectedItem = QuestionList[proximo];

            Answer1Enabled = true;
            Answer2Enabled = true;
            Answer3Enabled = true;

            Question = selectedItem.Question;
            Answer1 = selectedItem.Answer1;
            Answer2 = selectedItem.Answer2;
            Answer3 = selectedItem.Answer3;

            CorrectAnswer = selectedItem.CorrectAnswer;
            ListaNumeros.RemoveAt(0);
            IsLoading = false;
        }

        // método que gera n números aleatórios sem repetição
        static ArrayList numerosAleatorios(int inicio, int fim,  int quant)
        {

            // cria um objeto da classe Random
            Random rnd = new Random();

            // vamos preencher um ArrayList com a faixa de números
            ArrayList numeros = new ArrayList();
            for (int i = inicio; i < fim; i++)
            {
                numeros.Add(i);
            }

            // vamos embaralhar o ArrayList
            for (int i = 0; i < numeros.Count; i++)
            {
                int a = rnd.Next(numeros.Count);
                object temp = numeros[i];
                numeros[i] = numeros[a];
                numeros[a] = temp;
            }

            // vamos obter as quantidade de
            // que queremos
            return numeros.GetRange(0, quant);
        }

    }
}
