using Orbit.Engine;
using Orbit.GameObjects;
using System.Reflection;

namespace Orbit.Scenes;

public class HomeScene : GameScene
{
    private readonly IImageResourceContainer imageResourceContainer;

    public HomeScene(
        IImageResourceContainer imageResourceContainer,
        Ship ship,
        Sun sun,
        Planet planet)
    {
        this.imageResourceContainer = imageResourceContainer;

        Add(sun);
        Add(ship);
        Add(planet);
    }

    public override void Initialize()
    {
        var assembly = GetType().GetTypeInfo().Assembly;

        this.imageResourceContainer.Clear();
        this.imageResourceContainer.Add(assembly, "sun", "Orbit.Resources.EmbeddedResources.sun.png");
        this.imageResourceContainer.Add(assembly, "ship_none", "Orbit.Resources.EmbeddedResources.ship_none.png");
        this.imageResourceContainer.Add(assembly, "ship_forward", "Orbit.Resources.EmbeddedResources.ship_forward.png");
        this.imageResourceContainer.Add(assembly, "ship_reverse", "Orbit.Resources.EmbeddedResources.ship_reverse.png");
        this.imageResourceContainer.Add(assembly, "planet", "Orbit.Resources.EmbeddedResources.planet.png");

        base.Initialize();
    }
}
