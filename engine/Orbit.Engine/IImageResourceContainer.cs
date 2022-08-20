using System.Reflection;

namespace Orbit.Engine;

public interface IImageResourceContainer
{
    /// <summary>
    /// Adds the supplied <paramref name="imageResource"/> to this <see cref="IImageResource"/>.
    /// </summary>
    /// <param name="imageResource">The new <see cref="IImageResource"/> to add to the container.</param>
    void Add(Assembly assembly, string key, string imageName);

    /// <summary>
    /// Get an image resouce
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    IImageResource Get(string key);

    /// <summary>
    /// Removes the supplied <paramref name="imageResource"/> from this <see cref="IImageResource"/>.
    /// </summary>
    /// <param name="key">The key of the existing <see cref="IImageResource"/> to remove from the container.</param>
    void Remove(string key);

    void Clear();
}
