using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zdrowy_Spacer_forms.Services;
using Zdrowy_Spacer_forms.Views;

namespace Zdrowy_Spacer_forms
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
