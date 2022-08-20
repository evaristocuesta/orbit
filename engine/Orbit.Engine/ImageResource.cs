using System.Reflection;
#if WINDOWS
using Microsoft.Maui.Graphics.Win2D;
#else
using Microsoft.Maui.Graphics.Platform;
#endif

namespace Orbit.Engine;

public class ImageResource : IImageResource
{
    private Microsoft.Maui.Graphics.IImage _image;

    public string Key { get; private set; }

    public Microsoft.Maui.Graphics.IImage GetImage()
    {
        return _image;
    }

    public void LoadImage(Assembly assembly, string key, string imageName)
    {
        Key = key;

        using (var stream = assembly.GetManifestResourceStream(imageName))
        {
#if WINDOWS
            _image =  new W2DImageLoadingService().FromStream(stream);
#else
            _image = PlatformImage.FromStream(stream);
#endif
        }
    }
}
