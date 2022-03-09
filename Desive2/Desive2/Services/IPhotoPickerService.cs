using System.IO;
using System.Threading.Tasks;

namespace Desive2.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
