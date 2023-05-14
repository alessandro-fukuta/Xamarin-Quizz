using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xTCC_Questoes
{
    public partial class UserSignUp : ContentPage
    {
        public UserSignUp()
        {
            InitializeComponent();

            btnStart.IsEnabled = false;

            entryUsername.TextChanged += delegate
            {
                if (entryUsername.Text.Trim() != String.Empty) btnStart.IsEnabled = true;
                else btnStart.IsEnabled = false;
            };
        }

        public void NavigateToQuiz(object sender, EventArgs args)
        {
            AppSettings.Username = entryUsername.Text;
            Application.Current.MainPage = new SingleQuiz();
        }
    }
}
