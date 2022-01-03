using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zdrowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        IAuth auth;
        public Login()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);

            if (token != string.Empty)
            {
                //Application.Current.MainPage = new Login();
                await Shell.Current.GoToAsync($"///{nameof(Strona_glowna)}");
            }
            else
            {
                await DisplayAlert("Authentication Failed", "Email or Password are incorrect", "Ok");
            }
        }

        async void SignUpClicked(object sender, EventArgs e)
        {


            await Shell.Current.GoToAsync($"///{nameof(Registration)}");

        }


        async void SkipClicked(object sender, EventArgs e)
        {


            await Shell.Current.GoToAsync($"///{nameof(Strona_glowna)}");

        }


    }
}