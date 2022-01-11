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

        private async void BtnPickPhoto_Clicked(object sender, EventArgs e)
        {
            var Cross_Media = CrossMedia.Current;

            if (Cross_Media.IsPickPhotoSupported == true)
            {
                var FileImage = await Cross_Media.PickPhotoAsync();
                if (FileImage == null) return;
                await DisplayAlert("Test", "The Photo Is Get", "Done");
                imgCam.Source = ImageSource.FromFile(FileImage.Path);
            }
            else
            {
                await DisplayAlert("Error!", "Is Not Supported", "Done");
            }
        }

    }
}