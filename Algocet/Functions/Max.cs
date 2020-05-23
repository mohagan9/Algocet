using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Algocet.Functions
{
    public class Max : Function
    {
        protected override string SOLUTION_SNIPPET => "if (A[i] > register) { register = A[i]; }";

        public Max()
        {
            Initialise();
        }

        public Max (Constraint constraint)
        {
            Initialise();
            
            if (constraint.GetType() == typeof(NegativeConstraint))
            {
                RegisterStatements[0] = RegisterSyntaxFactory.InitialiseTo(int.MinValue);
            }
            ForLoops[0] = ForLoops[0].WithStatement(constraint.Apply((IfStatementSyntax)ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
