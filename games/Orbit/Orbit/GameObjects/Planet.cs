﻿using Orbit.Engine;

namespace Orbit.GameObjects;

public class Planet : GameObject
{
    Microsoft.Maui.Graphics.IImage image;
    float angle = 0;
    const float rotationIncrement = -0.25f;
    private readonly IGameSceneManager gameSceneManager;
    private readonly IImageResourceContainer imageResourceContainer;

    public int HealthPoints { get; private set; } = 100;

    public Planet(
        IGameSceneManager gameSceneManager,
        IImageResourceContainer imageResourceContainer,
        Shadow shadow)
    {
        this.gameSceneManager = gameSceneManager;
        this.imageResourceContainer = imageResourceContainer;

        Add(shadow);

        shadow.Planet = this;
    }

    public override void Initialize()
    {
        base.Initialize();

        image = imageResourceContainer.Get("planet").GetImage();
    }

    public override bool IsCollisionDetectionEnabled => true;

    public override void Render(ICanvas canvas, RectF dimensions)
    {
        base.Render(canvas, dimensions);

        canvas.Rotate(angle, dimensions.Center.X, dimensions.Center.Y);

        var size = Math.Min(dimensions.Width, dimensions.Height) / 4;

        Bounds = new RectF(
            dimensions.Center.X - size,
            dimensions.Center.Y - size,
            size * 2,
            size * 2);

        canvas.DrawImage(image, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

        if (MainPage.ShowBounds)
        {
            //canvas.RestoreState();

            canvas.StrokeColor = Colors.OrangeRed;
            canvas.StrokeSize = 4;
            canvas.DrawRectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

            //canvas.ResetState();
        }
    }

    public override void Update(double millisecondsSinceLastUpdate)
    {
        base.Update(millisecondsSinceLastUpdate);

        angle += rotationIncrement;
    }

    public void OnHit(int damage)
    {
        HealthPoints = Math.Max(HealthPoints - damage, 0);

        if (HealthPoints == 0)
        {
            gameSceneManager.GameOver();
        }
    }
}
