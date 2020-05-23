using Algocet.Functions;
using CodingChallenges.Util;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class ComplementTests : IArrayLengthTests
    {
        private readonly ProblemSolution complementSolution;

        public ComplementTests()
        {
            complementSolution = new ProblemSolution(new Complement());
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(
                Enumerable.Range(-1 * MILLION, (2 * MILLION)+1).ToArray(),
                complementSolution.SolveAsArray(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            Assert.Equal(
                new int[] { },
            complementSolution.SolveAsArray(Enumerable.Range(-1 * MILLION, (2 * MILLION)+1).ToArray()));
        }

        [Fact]
        public void SingleElement()
        {
            Assert.Equal(
                Enumerable.Range(-1 * MILLION, 2 * MILLION).ToArray(),
                complementSolution.SolveAsArray(new int[] { 1 * MILLION }));
        }
    }
}
