using Orbit.Engine;

namespace Orbit.GameObjects;

public class Sun : GameObject
{
    private IImageResourceContainer imageResourceContainer;
    Microsoft.Maui.Graphics.IImage image;

    public Sun(IImageResourceContainer imageResourceContainer)
    {
        this.imageResourceContainer = imageResourceContainer;


    }

    public override void Initialize()
    {
        base.Initialize();

        image = imageResourceContainer.Get("sun").GetImage();
    }

    public override void Render(ICanvas canvas, RectF dimensions)
    {
        base.Render(canvas, dimensions);

        var size = Math.Min(dimensions.Width, dimensions.Height) / 2;

        var halfWidth = size / 2;
        var halfHeight = size / 2;
        canvas.DrawImage(image, -halfWidth, -halfHeight, size, size);
    }
}
