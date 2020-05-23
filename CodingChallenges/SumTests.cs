using CodingChallenges.Util;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;
using System.Linq;
using Algocet.Functions;

namespace CodingChallenges
{
    public class SumTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution sumSolution;

        public SumTests()
        {
            sumSolution = new ProblemSolution(new Sum());
        }

        [Theory]
        [InlineData(new int[] { -92707930, 29, -BILLION, -1, 1 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(-1092707901, sumSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 92707930, -29, BILLION, 1, -1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(1092707901, sumSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 0, 0, -29, BILLION, 30, 0 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(BILLION+1, sumSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(0, sumSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] negativeToPositive = Enumerable.Range(-10 * THOUSAND, (20 * THOUSAND)+1).ToArray();
            int[] allPositive = Enumerable.Range(0, (20 * THOUSAND) + 1).ToArray();
            int[] allNegative = Enumerable.Range(-20 * THOUSAND, (20 * THOUSAND) + 1).ToArray();

            Assert.Equal(0, sumSolution.Solve(negativeToPositive));
            Assert.Equal(200010000, sumSolution.Solve(allPositive));
            Assert.Equal(-200010000, sumSolution.Solve(allNegative));
        }

        [Fact]
        public void SingleElement()
        {
            int sum = sumSolution.Solve(new int[] { int.MaxValue });
            Assert.Equal(int.MaxValue, sum);
        }
    }
}
