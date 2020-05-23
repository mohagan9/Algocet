using Algocet.Constraints;
using Algocet.Functions;
using CodingChallenges.Util;
using System;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class UnpairedPositiveTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution unpairedSolution;

        public UnpairedPositiveTests()
        {
            unpairedSolution = new ProblemSolution(new Unpaired(new PositiveConstraint()));
        }

        [Theory]
        [InlineData(new int[] { 8, int.MinValue, -24880, int.MinValue, -24880, 8, int.MinValue, 11, 12, 12, 11, 13, 13, 11 })]
        [InlineData(new int[] { -8, int.MinValue, 11, 24880, MILLION, 24880, -8, MILLION, 9, 9 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(11, unpairedSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 8, int.MaxValue, -24880, -11, int.MaxValue, -24880, 8, int.MaxValue })]
        [InlineData(new int[] { -8, int.MaxValue, 24880, MILLION, 24880, -8, MILLION, 9, 9, -11 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(int.MaxValue, unpairedSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 24880, int.MinValue, int.MaxValue, 0, 1, int.MaxValue, 24880, int.MinValue })]
        [InlineData(new int[] { 24880, int.MinValue, int.MaxValue, 0, int.MaxValue, 0, 1, 24880, int.MinValue, 0 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(1, unpairedSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(0, unpairedSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Repeat(int.MaxValue, 2 * MILLION).
                Append(int.MinValue).
                Append(int.MaxValue).
                ToArray();
            Assert.Equal(int.MaxValue, unpairedSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int unpaired = unpairedSolution.Solve(new int[] { 1 });
            Assert.Equal(1, unpaired);
        }
    }
}
