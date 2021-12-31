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
    public partial class Registration : ContentPage
    {
        IAuth auth;
        public Registration()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void SignUpClicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);

            if (user != null)
            {
                await DisplayAlert("Success", "New User Created", "Ok");

                var signOut = auth.SignOut();

                if (signOut)
                {
                    await Shell.Current.GoToAsync($"///{nameof(Login)}");
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Something went wrong, please try again", "Ok");
            }

        }

    }
}