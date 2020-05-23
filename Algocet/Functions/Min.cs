using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace Algocet.Functions
{
    public class Min : Function
    {
        protected override string SOLUTION_SNIPPET => "if (A[i] < register) { register = A[i]; }";

        public Min()
        {
            Initialise();
        }

        public Min(Constraint constraint)
        {
            Initialise();

            if (constraint.GetType() == typeof(PositiveConstraint))
            {
                RegisterStatements[0] = RegisterSyntaxFactory.InitialiseTo(int.MaxValue);
            }
            ForLoops[0] = ForLoops[0].WithStatement(constraint.Apply((IfStatementSyntax)ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
