using AppTest03.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Stormlion.ImageCropper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Preferences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrefNamePage : ContentPage
    {
        PrefNamePage_VM _PrefName;
        private MediaFile _mediaFile;

        public PrefNamePage()
        {
            InitializeComponent();
            BindingContext = _PrefName = new PrefNamePage_VM(); // Binding el Viewmodel
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _PrefName.OnAppearing();
        }

        private void P_foto_Tapped(object sender, EventArgs e)
        {
            try
            {
                new ImageCropper()
                {
                    PageTitle = "Test Title",
                    AspectRatioX = 1,
                    AspectRatioY = 1,
                    CropShape = ImageCropper.CropShapeType.Rectangle,
                    SelectSourceTitle = "Select source",
                    TakePhotoTitle = "Take Photo",
                    PhotoLibraryTitle = "Photo Library",
                    Success = (imageFile) =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //image.Source = ImageSource.FromFile(imageFile);
                            _PrefName.P_foto = ImageSource.FromFile(imageFile);
                            var stream = File.Open(imageFile, FileMode.Open);
                            string Ext = imageFile.Substring(imageFile.Length - 4);
                            _PrefName.New_Picure(stream,Ext);
                        });
                    }
                }.Show(this);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CameraException:>" + ex);
            }
        }
    }
}
