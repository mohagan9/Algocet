using Algocet.Constraints;
using Algocet.Functions;
using CodingChallenges.Util;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class MinPositiveMissingIntegerTests : IArrayLengthTests, IElementSignTests
    {
        private readonly ProblemSolution solution;

        public MinPositiveMissingIntegerTests()
        {
            solution = new ProblemSolution(new NestedFunction(new Min(), new Complement(new PositiveConstraint())));
        }

        [Theory]
        [InlineData(new int[] { -1, -1, -5579, -1, -1834, -1, -446518, -1, -1 })]
        public void AllNegative(int[] A)
        {
            Assert.Equal(1, solution.Solve(A));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5579, 5, 1834, 5, 446518, 3, 1 })]
        public void AllPositive(int[] A)
        {
            Assert.Equal(4, solution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(1, solution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            Assert.Equal(
                1 * MILLION, 
                solution.Solve(Enumerable.Range(-1 * MILLION, 2 * MILLION).ToArray()));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(2, solution.Solve(new int[] { 1 }));
        }
    }
}
