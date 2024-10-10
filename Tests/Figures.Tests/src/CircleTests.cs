using System;
using Figures.Core.Shapes;
using Figures.Tests.Utils;

namespace Figures.Tests;

public class CircleTests
{
    [Fact]
    public void Constructor_Circle_CreatedSuccessfully()
    {
        Exception? exception = Record.Exception(() => new Circle(5.3));
        Assert.Null(exception);
    }

    [Fact]
    public void Constructor_CircleWithIncorrectRadius_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
    }

    [Fact]
    public void Area_GeneratedCircle_AreaCalculatedCorrectly()
    {
        for (double radius = 1; radius <= 100000; radius += 0.1)
        {
            VerifyCircleAreaIsCorrect(radius);
        }
    }

    [Fact]
    public void Area_LargeCircle_AreaCalculatedCorrectly()
    {
        VerifyCircleAreaIsCorrect(9987665.92386);
    }

    private static void VerifyCircleAreaIsCorrect(double radius)
    {
        var circle = new Circle(radius);

        double expectedArea = Math.PI * radius * radius;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(circle, expectedArea);

        Assert.True(isAreaCorrect);
    }
}
