using System.Collections.Generic;

namespace Figures.Tests.Utils;

public static class PythagoreanTripleGenerator
{
    public static IEnumerable<(int A, int B, int C)> Generate(int baseNumberLimit)
    {
        for (int m = 2; m < baseNumberLimit; ++m)
        {
            for (int n = 1; n < m; ++n)
            {
                int a = (m * m) - (n * n);
                int b = 2 * m * n;
                int c = (m * m) + (n * n);

                yield return (a, b, c);
            }
        }
    }
}
