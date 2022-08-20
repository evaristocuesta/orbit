using System.Reflection;

namespace Orbit.Engine;

/// <summary>
/// Base class definition representing an object in a game.
/// </summary>
public abstract class GameObject : GameObjectContainer, IGameObject, IDrawable
{
    public RectF Bounds { get; protected set; }

    public GameScene CurrentScene { get; internal set; } // TODO: weak reference?

    public virtual bool IsCollisionDetectionEnabled { get; }

    public virtual void Initialize()
    {
        foreach (var gameObject in GameObjectsSnapshot)
        {
            gameObject.Initialize();
        }
    }

    void IDrawable.Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        canvas.ResetState();

        Render(canvas, dirtyRect);

        canvas.RestoreState();
    }
}
