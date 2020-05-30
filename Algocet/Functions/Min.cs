using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Algocet.Functions
{
    public class Min : Function
    {
        protected string SOLUTION_SNIPPET => "if (A[i] < registerMin) { registerMin = A[i]; }";

        public Min()
        {
            Initialise();
        }

        public Min(Constraint constraint)
        {
            Initialise();

            if (constraint.GetType() == typeof(PositiveConstraint))
            {
                RegisterStatements[0] = SyntaxProvider.InitialiseTo(int.MaxValue);
            }
            ForLoops[0] = ForLoops[0].WithStatement(constraint.Apply((IfStatementSyntax)ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }

        protected override void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateDefaultMethod();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareInt() };
            RegisterStatements = new List<StatementSyntax> { SyntaxProvider.InitialiseToElementAt(0) };
            ForLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(StatementSyntaxFactory.CreateIfStatement(SOLUTION_SNIPPET))
            };
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
