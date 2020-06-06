using Algocet.Functions;
using CodingChallenges.Util;
using System.Linq;
using Xunit;
using static CodingChallenges.Util.CommonIntegers;

namespace CodingChallenges
{
    public class SingleMissingNaturalNumberTests : IArrayLengthTests
    {
        private readonly ProblemSolution missingNaturalNumberSolution;

        public SingleMissingNaturalNumberTests()
        {
            missingNaturalNumberSolution = new ProblemSolution(new Unpaired(Unpaired.Mode.NATURAL));
        }

        [Fact]
        public void MiddleMissing()
        {
            int[] A = Enumerable.Range(1, 100 * THOUSAND).
                Concat(Enumerable.Range((100 * THOUSAND) + 2, MILLION - (100*THOUSAND))).
                ToArray();
            Assert.Equal((100 * THOUSAND) + 1, missingNaturalNumberSolution.Solve(A));
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(1, missingNaturalNumberSolution.Solve(new int[] { }));
        }

        [Fact]
        public void MaxCapacity()
        {
            int[] A = Enumerable.Range(1, MILLION).ToArray();
            Assert.Equal(MILLION + 1, missingNaturalNumberSolution.Solve(A));
        }

        [Fact]
        public void SingleElement()
        {
            int missingNaturalNumber = missingNaturalNumberSolution.Solve(new int[] { 2 });
            Assert.Equal(1, missingNaturalNumber);
        }
    }
}
