using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Desive2.Models
{
    public  class ByteImage : Image
    {
        public Func<byte[]> GetBytes { get; set; }
    }
}
