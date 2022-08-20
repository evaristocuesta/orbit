using System.Reflection;

namespace Orbit.Engine;

public interface IImageResource
{
    string Key { get; }

    /// <summary>
    /// Get the image to render it
    /// </summary>
    /// <returns>Returns the image</returns>
    Microsoft.Maui.Graphics.IImage GetImage();
    
    /// <summary>
    /// Load the image and store the key
    /// </summary>
    /// <param name="key">Key of the image</param>
    /// <param name="imageName">name of the image</param>
    void LoadImage(Assembly assembly, string key, string imageName);
}
