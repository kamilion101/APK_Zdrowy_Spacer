using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    public partial class App : Application
    {
        IAuth auth;
        public App()
        {
            InitializeComponent();

            auth = DependencyService.Get<IAuth>();

            if (auth.IsSignIn())
            {
                MainPage = new LoggedPage();
            }else
            {
                MainPage = new MainPage();
            }

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
