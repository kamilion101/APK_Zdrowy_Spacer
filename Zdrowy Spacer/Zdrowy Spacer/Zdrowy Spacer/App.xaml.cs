using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zdrowy_Spacer.Services;
using Zdrowy_Spacer.Views;

namespace Zdrowy_Spacer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
