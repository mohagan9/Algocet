using Algocet.Constraints;
using Algocet.Functions;
using CodingChallenges.Util;
using System.Collections;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class ComplementPositiveTests : IArrayLengthTests, IElementSignTests
    {
        private readonly ProblemSolution complementSolution;

        public ComplementPositiveTests()
        {
            complementSolution = new ProblemSolution(new Complement(new PositiveConstraint()));
        }

        [Theory]
        [InlineData(new int[] { -1, -1, -5579, -1, -1834, -1, -446518, -1, -1 })]
        public void AllNegative(int[] A)
        {
            Assert.Equal(
                Enumerable.Range(1, 1 * MILLION),
                complementSolution.SolveAsArray(A));
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 5579, 1, 1834, 1, 446518, 1, 1 })]
        public void AllPositive(int[] A)
        {
            IEnumerable expected = Enumerable.
                Range(1, 1 * MILLION).
                Except(A);

            Assert.Equal(expected, complementSolution.SolveAsArray(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(
                Enumerable.Range(1, 1 * MILLION), 
                complementSolution.SolveAsArray(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            Assert.Equal(
                new int[] { },
                complementSolution.SolveAsArray(Enumerable.Range(-1 * MILLION, (2 * MILLION) + 1).ToArray()));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(
                Enumerable.Range(1, (1 * MILLION)-1).ToArray(),
                complementSolution.SolveAsArray(new int[] { 1 * MILLION }));
        }
    }
}
