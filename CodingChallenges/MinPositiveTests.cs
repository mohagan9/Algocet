using Algocet;
using Algocet.Constraints;
using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class MinPositiveTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution minSolution;

        public MinPositiveTests()
        {
            minSolution = new ProblemSolution(new Min(new PositiveConstraint()));
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, 8, -1, -24880, 7 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(7, minSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, -8, MILLION, 24880, -1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(24880, minSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, 8, 2, 24880, 2 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(2, minSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(int.MaxValue, minSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, 2 * MILLION).ToArray();
            Assert.Equal(1, minSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int min = minSolution.Solve(new int[] { 99 });
            Assert.Equal(99, min);
        }
    }
}
