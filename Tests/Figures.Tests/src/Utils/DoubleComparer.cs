using System;

namespace Figures.Tests.Utils;

public static class DoubleComparer
{
    public static bool AreEqual(double x, double y)
    {
        double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * 1e-15;
        return Math.Abs(x - y) <= epsilon;
    }
}
