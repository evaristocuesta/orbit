using System.Reflection;

namespace Orbit.Engine;

public class ImageResourceContainer : IImageResourceContainer
{
    private readonly IDictionary<string, IImageResource> _images = new Dictionary<string, IImageResource>();

    
    public void Add(Assembly assembly, string key, string imageName)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(imageName);

        var image = new ImageResource();
        image.LoadImage(assembly, key, imageName);

        _images.Add(key, image);
    }

    public void Clear()
    {
        _images.Clear();
    }

    public IImageResource Get(string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        return _images[key];
    }

    public void Remove(string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        _images.Remove(key);
    }
}
