using CodingChallenges.Util;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;
using System.Linq;
using Algocet.Functions;
using Algocet.Constraints;

namespace CodingChallenges
{
    public class SumNegativeTests : IArrayLengthTests, IElementExtremeTests
    {
        private readonly ProblemSolution sumSolution;

        public SumNegativeTests()
        {
            sumSolution = new ProblemSolution(new Sum(new NegativeConstraint()));
        }

        [Theory]
        [InlineData(new int[] { -92707930, 29, -BILLION, -1, 1 })]
        public void ContainsExtremeNegative(int[] A)
        {
            Assert.Equal(-1092707931, sumSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 92707930, -29, BILLION, 1, -1 })]
        public void ContainsExtremePositive(int[] A)
        {
            Assert.Equal(-30, sumSolution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 0, 0, -29, BILLION, 30, 0 })]
        public void ContainsZero(int[] A)
        {
            Assert.Equal(-29, sumSolution.Solve(A));
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

            Assert.Equal(-50005000, sumSolution.Solve(negativeToPositive));
            Assert.Equal(0, sumSolution.Solve(allPositive));
            Assert.Equal(-200010000, sumSolution.Solve(allNegative));
        }

        [Fact]
        public void SingleElement()
        {
            int sum = sumSolution.Solve(new int[] { int.MaxValue });
            Assert.Equal(0, sum);
        }
    }
}
