using System;
using Desive2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(Desive2.Models.ByteImage), typeof(CustomImage.iOS.ByteImageRenderer))]
namespace CustomImage.iOS
{
    public class ByteImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            var newImage = e.NewElement as ByteImage;
            if (newImage != null)
            {
                newImage.GetBytes = () =>
                {
                    return this.Control.Image.AsPNG().ToArray();
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