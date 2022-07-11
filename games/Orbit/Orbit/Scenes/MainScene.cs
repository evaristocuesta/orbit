﻿using Orbit.Engine;
using Orbit.GameObjects;

namespace Orbit;

public class MainScene : GameScene
{
    public MainScene(
        Ship ship,
        Sun sun,
        Planet planet,
        BatteryLevel batteryLevel,
        AsteroidLauncher asteroidLauncher)
    {
        Add(sun);
        Add(ship);
        Add(planet);
        Add(batteryLevel);
        Add(asteroidLauncher);
    }
}
