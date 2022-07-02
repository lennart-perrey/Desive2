using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using Android;

namespace Desive2.Droid
{
    [Activity(Label = "DESIVE²", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@mipmap/launcher_foreground", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Hier später nochmal schauen ob wir das woanders hin packen wollen!
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.RecordAudio }, 1);
            }

            LoadApplication(new App());
            Instance = this;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if(requestCode == PickImageId)
            {
                if((resultCode==Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);
                    PickImageTaskCompletionSource.SetResult(stream);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }

        }
    }
}