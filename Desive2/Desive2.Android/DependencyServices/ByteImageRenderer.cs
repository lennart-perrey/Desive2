using System;
using System.IO;
using Android.Graphics;
using Desive2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: ExportRenderer(typeof(Desive2.Models.ByteImage), typeof(Desive2.Droid.DependencyServices.ByteImageRenderer))]
namespace Desive2.Droid.DependencyServices
{
    public class ByteImageRenderer : ImageRenderer
    {
        public ByteImageRenderer() : base(Application.Context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            var newImage = e.NewElement as ByteImage;

            if(newImage != null)
            {
                newImage.GetBytes = () =>
                {
                    var drawable = this.Control.Drawable;
                    var bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
                    drawable.Draw(new Canvas(bitmap));
                    using (var ms = new MemoryStream())
                    {
                        bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
                        return ms.ToArray();
                    }

                };
            }
            var oldImage = e.OldElement as ByteImage;
            if (oldImage != null)
            {
                oldImage.GetBytes = null;
            }
        }
    }
}