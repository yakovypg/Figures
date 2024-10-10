using System;

namespace Figures.Core.Shapes;

public class Circle : IShape
{
    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius, nameof(radius));
        Radius = radius;
    }

    public double Radius { get; }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}
