using Desive2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class UploadPageViewModel : BindableObject
    {
        public UploadPageViewModel()
        {
            PhotoPicker = new Command(PickPhoto);
            Title = "Bilder hochladen";
        }
        public string Title{ get; set; }
        public ICommand PhotoPicker { get; set; }

        private bool isButtonActive = true;
        public bool IsButtonActive
        {
            get => isButtonActive;
            set { isButtonActive = value; }
        }

        private Image _image = new Image();
        public Image Image {
            get => _image;
            private set { _image = value; }
        
        }
       

        async void PickPhoto()
        {

            try
            {

                IsButtonActive = false;
                Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if(stream != null)
                {
                    Image.Source = ImageSource.FromStream(() => stream);
                }
                IsButtonActive = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
           
            }
        }
    }
}