using Desive2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
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
            UploadPicture = new Command(Upload);
            Title = "Bilder hochladen";
  
        }
        private bool isUploadVisible = false;
        public bool IsUploadVisible
        {
            get => isUploadVisible;
            set
            {
                isUploadVisible = value; ;
                OnPropertyChanged();
            }
        }
        private string buttonText = "Foto auswählen";
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                OnPropertyChanged(); 
            }
        }
        public string Title{ get; set; }
        public ICommand PhotoPicker { get; set; }
        public ICommand UploadPicture { get; set; }
        

        private Image _image = new Image();
        public Image Image {
            get => _image;
            private set { _image = value; }
        
        }

        private long _streamLength;
        public long StreamLength
        {
            get => _streamLength;
            private set { _streamLength = value; }

        }
        private Stream stream;
        async void PickPhoto()
        {

            try
            {

         
                stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if(stream != null)
                {
                    Image.Source = ImageSource.FromStream(() => stream);
                    StreamLength = stream.Length;
                }
                IsUploadVisible = true;
                ButtonText = "Anderes Foto hochladen";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
           
            }
        }
        async void Upload()
        {
            
        }

        
    }

 
}