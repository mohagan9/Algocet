using Algocet.Functions;
using CodingChallenges.Util;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class UnpairedTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution unpairedSolution;

        public UnpairedTests()
        {
            unpairedSolution = new ProblemSolution(new Unpaired());
        }

        [Theory]
        [InlineData(new int[] { 8, int.MinValue, -24880, int.MinValue, -24880, 8, int.MinValue })]
        [InlineData(new int[] { -8, int.MinValue, 24880, MILLION, 24880, -8, MILLION, 9, 9 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(int.MinValue, unpairedSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 8, int.MaxValue, -24880, int.MaxValue, -24880, 8, int.MaxValue })]
        [InlineData(new int[] { -8, int.MaxValue, 24880, MILLION, 24880, -8, MILLION, 9, 9 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(int.MaxValue, unpairedSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 24880, int.MinValue, int.MaxValue, 0, int.MaxValue, 24880, int.MinValue })]
        [InlineData(new int[] { 24880, int.MinValue, int.MaxValue, 0, int.MaxValue, 0, 24880, int.MinValue, 0 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(0, unpairedSolution.Solve(A));
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
                ToArray();
            Assert.Equal(int.MinValue, unpairedSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int unpaired = unpairedSolution.Solve(new int[] { 0 });
            Assert.Equal(0, unpaired);
        }
    }
}
