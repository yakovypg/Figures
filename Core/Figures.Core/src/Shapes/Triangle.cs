using System;
using Figures.Core.Exceptions;

namespace Figures.Core.Shapes;

public class Triangle : IShape
{
    public Triangle(double firstSideLength, double secondSideLength, double thirdSideLength)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(firstSideLength, nameof(firstSideLength));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(secondSideLength, nameof(secondSideLength));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(thirdSideLength, nameof(thirdSideLength));

        if (!Exists(firstSideLength, secondSideLength, thirdSideLength))
            throw new ShapeNotExistException(null, nameof(Triangle));

        double[] sides = [firstSideLength, secondSideLength, thirdSideLength];
        Array.Sort(sides);

        SmallestSideLength = sides[0];
        MediumSizeSideLength = sides[1];
        LargestSideLength = sides[2];
    }

    public double SmallestSideLength { get; }
    public double MediumSizeSideLength { get; }
    public double LargestSideLength { get; }

    public static bool Exists(double firstSideLength, double secondSideLength, double thirdSideLength)
    {
        return firstSideLength > 0
            && secondSideLength > 0
            && thirdSideLength > 0
            && firstSideLength + secondSideLength > thirdSideLength
            && firstSideLength + thirdSideLength > secondSideLength
            && secondSideLength + thirdSideLength > firstSideLength;
    }

    public bool IsRight()
    {
        return LargestSideLength * LargestSideLength ==
            (SmallestSideLength * SmallestSideLength) + (MediumSizeSideLength * MediumSizeSideLength);
    }

    public double Area()
    {
        if (IsRight())
            return 0.5 * SmallestSideLength * MediumSizeSideLength;

        double semiperimeter = 0.5 * (SmallestSideLength + MediumSizeSideLength + LargestSideLength);

        double product = semiperimeter *
            (semiperimeter - SmallestSideLength) *
            (semiperimeter - MediumSizeSideLength) *
            (semiperimeter - LargestSideLength);

        return Math.Sqrt(product);
    }
}
