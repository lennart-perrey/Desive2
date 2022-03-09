using Android.Content;
using Desive2.Droid;
using Desive2.Services;
using System.IO;

using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace Desive2.Droid
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Stream> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            //Start the picture picker activity
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Wähle ein Foto aus"),
                MainActivity.PickImageId);

            //Save the TaskCompletionSource object as a MainActivity prop
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            //return task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}