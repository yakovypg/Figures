using System;
using Figures.Core.Shapes;

namespace Figures.Tests.Utils;

public static class ShapeAreaValidator
{
    public static bool IsAreaCorrect(IShape shape, double expectedArea)
    {
        ArgumentNullException.ThrowIfNull(shape, nameof(shape));

        double actualArea = shape.Area();
        return DoubleComparer.AreEqual(expectedArea, actualArea);
    }
}
