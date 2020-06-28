using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class MaxCountTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution problemSolution;

        public MaxCountTests()
        {
            problemSolution = new ProblemSolution(new MergedFunction(new Max(), new Count()));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, -MILLION, 7, -MILLION, -MILLION })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(-MILLION, problemSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, MILLION, 7, MILLION, MILLION })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(MILLION, problemSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, 0, 0, -511, 0, -588459, 1, 7, 0, 1, 1 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(0, problemSolution.Solve(A));
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
            Assert.Equal(-MILLION, problemSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(5, problemSolution.Solve(new int[] { 5 }));
        }

        [Fact]
        public void AllNegative()
        {
            Assert.Equal(-3, problemSolution.Solve(new int[] { -9, -4, -3, -2, -3, -2, -3, -5, -8 }));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, 2, 2, -511, 2, -588459, 1, 7, 0, 1, 1 })]
        [InlineData(new int[] { -511, 7, 2, 2, -511, 2, -588459, 3, 7, 0, 3, 3 })]
        public void DefaultIsFirstMaxOccurrence(int[] A)
        {
            Assert.Equal(2, problemSolution.Solve(A));
        }
    }
}
