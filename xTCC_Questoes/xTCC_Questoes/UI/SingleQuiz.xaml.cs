using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xTCC_Questoes
{
    public partial class SingleQuiz : ContentPage
    {
        int _choice = 0;
        int score = 100;

        public SingleQuiz()
        {
            InitializeComponent();
            ((QuestionViewModel)BindingContext).LoadQuestions();

            btnAnswerOne.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(1)) DoAnswer();
                else
                {
                    score = score / 2; DoAnswer();
                }
            };

            btnAnswerTwo.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(2)) DoAnswer();
                else
                {
                    score = score / 2; DoAnswer();
                }
            };

            btnAnswerThree.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(3))
                {
                    DoAnswer();
                }
                else
                {
                    score = score / 2; DoAnswer();
                }
            };
        }

        private void DoAnswer()
        {
            AppSettings.Score += score;
            if (AppSettings.CurrentQuestion < AppSettings.QUESTIONS_COUNT)
            {
                AppSettings.CurrentQuestion++;
                ((QuestionViewModel)BindingContext).ChooseNewQuestion();
            }
            else
            {
                NavigateToEndPage();
            }
        }

        private void NavigateToEndPage()
        {
            Application.Current.MainPage = new ThanksForPlaying();
        }
    }
}
