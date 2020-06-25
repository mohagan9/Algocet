using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class CountMaxTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution problemSolution;

        public CountMaxTests()
        {
            problemSolution = new ProblemSolution(new MergedFunction(new Count(), new Max()));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, -MILLION, 7, -MILLION, -MILLION })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(1, problemSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, MILLION, 7, MILLION, MILLION })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(3, problemSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, 0, 0, -511, 0, -588459, 1, 7, 0, 1, 1 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(2, problemSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            ReflectiveAssert.Throws<IndexOutOfRangeException>(() => problemSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, (2 * MILLION) + 1).ToArray();
            Assert.Equal(1, problemSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(1, problemSolution.Solve(new int[] { 5 }));
        }

        [Fact]
        public void AllNegative()
        {
            Assert.Equal(2, problemSolution.Solve(new int[] { -9, -4, -3, -2, -3, -2, -3, -5, -8 }));
        }
    }
}
