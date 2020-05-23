using CodingChallenges.Util;
using Xunit;
using Algocet;
using System;
using System.Linq;
using static CodingChallenges.Util.CommonIntegers;
using Algocet.Functions;

namespace CodingChallenges
{
    public class MinTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution minSolution;

        public MinTests()
        {
            minSolution = new ProblemSolution(new Min());
        }

        [Theory]
        [InlineData(new int[] { int.MinValue, 0, 8, -1, -24880, 1 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(int.MinValue, minSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, -8, 1, 24880, -1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(-8, minSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { int.MaxValue, 0, 8, 1, 24880, 1 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(0, minSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            ReflectiveAssert.Throws<IndexOutOfRangeException>(() => minSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(-MILLION, 2 * MILLION).ToArray();
            Assert.Equal(-MILLION, minSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int min = minSolution.Solve(new int[] { int.MaxValue });
            Assert.Equal(int.MaxValue, min);
        }
    }
}
