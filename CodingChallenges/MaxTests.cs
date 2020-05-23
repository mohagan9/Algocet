using CodingChallenges.Util;
using Xunit;
using System;
using System.Linq;
using static CodingChallenges.Util.CommonIntegers;
using Algocet.Functions;

namespace CodingChallenges
{
    public class MaxTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution maxSolution;

        public MaxTests()
        {
            maxSolution = new ProblemSolution(new Max());
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, 8, -1, -24880, 1 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(8, maxSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, -8, 1, 24880, -1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(int.MaxValue, maxSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, -8, -1, -24880, -1 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(0, maxSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            ReflectiveAssert.Throws<IndexOutOfRangeException>(() => maxSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, 2 * MILLION).ToArray();
            Assert.Equal(MILLION-1, maxSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int max = maxSolution.Solve(new int[] { int.MinValue });
            Assert.Equal(int.MinValue, max);
        }
    }
}
