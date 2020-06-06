using Algocet.Functions;
using CodingChallenges.Util;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class CheckForPermutationTests : IArrayLengthTests
    {
        private readonly ProblemSolution permutationSolution;

        public CheckForPermutationTests()
        {
            permutationSolution = new ProblemSolution(new NestedFunction(new Check(Check.Mode.NOT), new Unpaired(Unpaired.Mode.NATURAL)));
        }

        [Fact]
        public void MiddleMissing()
        {
            int[] A = Enumerable.Range(1, 100 * THOUSAND).
                Concat(Enumerable.Range((100 * THOUSAND) + 2, MILLION - (100*THOUSAND))).
                ToArray();
            Assert.Equal(0, permutationSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(1, permutationSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(1, MILLION).ToArray();
            Assert.Equal(1, permutationSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int missingNaturalNumber = permutationSolution.Solve(new int[] { 2 });
            Assert.Equal(0, missingNaturalNumber);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 2 })]
        [InlineData(new int[] { 4, 2, 3, 2, 1 })]
        public void DuplicateElements(int[] A)
        {
            Assert.Equal(0, permutationSolution.Solve(A));
        }
    }
}
