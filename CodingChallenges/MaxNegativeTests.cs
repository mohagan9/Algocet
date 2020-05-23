using Algocet.Constraints;
using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class MaxNegativeTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution maxSolution;

        public MaxNegativeTests()
        {
            maxSolution = new ProblemSolution(new Max(new NegativeConstraint()));
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, 8, -7, -24880, 1 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(-7, maxSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, 8, 1, -24880, 1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(-24880, maxSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, -8, -2, -24880, -2 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(-2, maxSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(int.MinValue, maxSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, 2 * MILLION).ToArray();
            Assert.Equal(-1, maxSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int max = maxSolution.Solve(new int[] { -99 });
            Assert.Equal(-99, max);
        }
    }
}
