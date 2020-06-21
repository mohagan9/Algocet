using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class CountTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution problemSolution;

        public CountTests()
        {
            problemSolution = new ProblemSolution(new Count());
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, -MILLION, 7, -MILLION, -MILLION } )]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(3, problemSolution.Solve(A, -MILLION));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, -511, 588459, MILLION, 7, MILLION, MILLION })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(3, problemSolution.Solve(A, MILLION));
        }

        [Theory]
        [InlineData(new int[] { -511, 7, 0, 0, -511, 0, 588459, 1, 7, 0, 1, 1 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(4, problemSolution.Solve(A, 0));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(0, problemSolution.Solve(new int[] { }, 99));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, (2 * MILLION) + 1).ToArray();
            Assert.Equal(1, problemSolution.Solve(A, MILLION));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(1, problemSolution.Solve(new int[] { 5 }, 5));
        }

        [Fact]
        public void NotInArray()
        {
            Assert.Equal(0, problemSolution.Solve(new int[] { -9, -4, -1, 0, 1, 2, 3, 5, 8 }, 7));
        }
    }
}
