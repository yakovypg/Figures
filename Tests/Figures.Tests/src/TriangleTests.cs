using System;
using Figures.Core.Exceptions;
using Figures.Core.Shapes;
using Figures.Tests.Utils;

namespace Figures.Tests;

public class TriangleTests
{
    [Fact]
    public void Constructor_Triangle_CreatedSuccessfully()
    {
        Exception? exception = Record.Exception(() => new Triangle(2, 2, 3));
        Assert.Null(exception);
    }

    [Fact]
    public void Constructor_NonExistentTriangle_ThrowsException()
    {
        Assert.Throws<ShapeNotExistException>(() => new Triangle(1, 2, 33));
    }

    [Fact]
    public void Constructor_TriangleWithIncorrectSide_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 2, 3));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 0, 3));
    }

    [Fact]
    public void Exists_ExistingTriangle_True()
    {
        Assert.True(Triangle.Exists(2, 2, 3));
        Assert.True(Triangle.Exists(11.4, 22.15, 33));
        Assert.True(Triangle.Exists(23476.25, 23876, 34624.234));
    }

    [Fact]
    public void Exists_NonExistentTriangle_False()
    {
        Assert.False(Triangle.Exists(1, 2, 3));
        Assert.False(Triangle.Exists(11.4, 122.15, 33));
        Assert.False(Triangle.Exists(23476.25, 23876, 134624.234));
    }

    [Fact]
    public void IsRight_GeneratedRightTriangle_True()
    {
        foreach (var (a, b, c) in PythagoreanTripleGenerator.Generate(100))
        {
            var triangle = new Triangle(a, b, c);
            Assert.True(triangle.IsRight());
        }
    }

    [Fact]
    public void IsRight_Triangle_False()
    {
        var triangle = new Triangle(6, 3, 4);
        Assert.False(triangle.IsRight());
    }

    [Fact]
    public void Area_SmallTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(2, 3, 2);

        double expectedArea = 3 * Math.Sqrt(7) / 4;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }

    [Fact]
    public void Area_MediumSizeTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(192, 670, 675);

        double expectedArea = Math.Sqrt(65284639079L) / 4;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }

    [Fact]
    public void Area_LargeTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(567000, 192888, 560000);

        double expectedArea = 54272 * Math.Sqrt(972081043257L);
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }

    [Fact]
    public void Area_RightTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(3, 4, 5);

        const double expectedArea = 6;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }

    [Fact]
    public void Area_IsoscelesTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(987.55, 987.55, 1000.145);

        double expectedArea = Math.Sqrt(70839142130362580L) / 625;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }

    [Fact]
    public void Area_EquilateralTriangle_AreaCalculatedCorrectly()
    {
        var triangle = new Triangle(12345.6789, 12345.6789, 12345.6789);

        double expectedArea = 524288 * Math.Sqrt(2417917145651405L) / 390625;
        bool isAreaCorrect = ShapeAreaValidator.IsAreaCorrect(triangle, expectedArea);

        Assert.True(isAreaCorrect);
    }
}
