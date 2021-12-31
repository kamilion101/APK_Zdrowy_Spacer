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
    public partial class Strona_glowna : ContentPage
    {
        IAuth auth;
        public Strona_glowna()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        void SignOutButton_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();

            if (signOut)
            {
                Application.Current.MainPage = new MainPage();
            }
        }

    }
}