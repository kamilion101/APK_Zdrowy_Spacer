using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Zdrowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zdjecia : ContentPage
    {
        public Zdjecia()
        {
            InitializeComponent();
        }

        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "ZdrowySpacer",
                    SaveToAlbum = true,
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 92
                });

                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

    }
}