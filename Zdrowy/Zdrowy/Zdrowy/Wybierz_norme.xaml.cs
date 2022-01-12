using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zdrowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wybierz_norme : ContentPage
    {
        public Wybierz_norme()
        {
            InitializeComponent();
            NotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;

            NotificationCenter.Current.NotificationReceived += Current_NotificationReceived;

           

            
        }

        private void Current_NotificationReceived(NotificationEventArgs e)
        {
            DisplayAlert("Wybrana norma", e.Request.ReturningData, "Ok");
        }

        private void Current_NotificationActionTapped(NotificationActionEventArgs e)
        {
            DisplayAlert(e.Request.Title, e.Request.Description, "OK");
        }

        void norma(object sender, EventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            lab.Text = $"Ustalona norma to: {radioButton.Content}";
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = $"Wybrana tygodniowa norma to: {radioButton.Content}, wierzymy w Ciebie!",
                Title = "Gratulacje!",
                ReturningData = $"Zmieniono tygodniową normę na: {radioButton.Content}!",
                NotificationId = 1337,
                
            };

            NotificationCenter.Current.Show(notification);
        }
              
    }
}