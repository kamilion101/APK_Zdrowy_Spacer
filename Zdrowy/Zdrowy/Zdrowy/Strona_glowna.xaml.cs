using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
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

        private async void StartClicked(object sender, EventArgs e)
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000), null, true);
            LongitudeLabel.Text = position.Longitude.ToString();
            LatitudeLabel.Text = position.Latitude.ToString();

            Geocoder geoCoder = new Geocoder();
            Position position1 = new Position(position.Latitude, position.Longitude); 
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position1);
            string address = possibleAddresses.FirstOrDefault();
            nazwa.Text = address;

        }


        private async void StopClicked(object sender, EventArgs e)
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000), null, true);
            dlug.Text = position.Longitude.ToString();
            szer.Text = position.Latitude.ToString();

            Geocoder geoCoder = new Geocoder();
            Position position1 = new Position(position.Latitude, position.Longitude);
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position1);
            string address = possibleAddresses.FirstOrDefault();
            nazwa2.Text = address;

        }

        private async void WynikClicked(object sender, EventArgs e)
        {
          
            Geocoder geoCoder = new Geocoder();

            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(nazwa.Text);
            Position position = approximateLocations.FirstOrDefault();
            string coordinates = $"{position.Latitude}, {position.Longitude}";

            Geocoder geoCoder2 = new Geocoder();

            IEnumerable<Position> approximateLocations2 = await geoCoder2.GetPositionsForAddressAsync(nazwa2.Text);
            Position position2 = approximateLocations2.FirstOrDefault();
            string coordinates2 = $"{position2.Latitude}, {position2.Longitude}";

            Location poczatek = new Location(position.Latitude, position.Longitude);
            Location koniec = new Location(position2.Latitude, position2.Longitude);
            double Kilometers = Location.CalculateDistance(poczatek, koniec, DistanceUnits.Kilometers);

            Dystans.Text = Kilometers.ToString("#.###");
            Kroki.Text = (Kilometers / 0.0007).ToString("#");
            Kcal.Text = (Kilometers * 100).ToString("#");

        }

    }
}