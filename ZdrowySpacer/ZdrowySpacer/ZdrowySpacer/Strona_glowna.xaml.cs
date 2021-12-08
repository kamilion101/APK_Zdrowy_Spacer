using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZdrowySpacer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Strona_glowna : ContentPage
    {
        public Strona_glowna()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell .Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}