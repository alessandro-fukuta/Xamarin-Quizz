//using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace xTCC_Questoes
{
    public class AppSettings
    {
        public const int QUESTIONS_COUNT = 7;
        public static int CurrentQuestion = 1;
        public static int Score = 0;
        public static string Username = "";

    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*
            XamarinQuiz item = new XamarinQuiz()
            {
                Question = "La sigla PCL se refiere a...",
                Answer1 = "Portable Class Library",
                Answer2 = "Power Class Library",
                Answer3 = "Portable Code Library",
                CorrectAnswer = 1
            };

            */

            MainPage = new UserSignUp();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
