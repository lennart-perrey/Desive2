using Desive2.Services;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Desive2.Models;
using Xamarin.Essentials;

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
        public ByteImage Logo{ get; set; }
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

        
        public string Base64 { get; set; }
        async void PickPhoto()
        {

            try
            {


                Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                if (stream != null)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        stream.CopyTo(memory);
                        byte[] bytes = memory.ToArray();
                        Image.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
                            
                        Base64 = System.Convert.ToBase64String(bytes);
                    }
                    
                }
                IsUploadVisible = true;
                ButtonText = "Anderes Foto hochladen";
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
           
            }
        }
        void Upload()
        {
            string user = Preferences.Get("idUser", null);
            bool upload = false;
            if (user != null)
            {
                upload = Database.UploadPicture(user, Base64);
                
            }
          
        }

       

    }

 
}