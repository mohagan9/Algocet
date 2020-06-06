using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Min : Function, IParentFunction
    {
        protected string SOLUTION_SNIPPET => "if (A[i] < registerMin) { registerMin = A[i]; }";

        public Function Function => this;

        public Min()
        {
            Initialise();
        }

        public Min(Constraint constraint)
        {
            Initialise();

            if (constraint.GetType() == typeof(PositiveConstraint))
            {
                RegisterStatements[0] = SyntaxProvider.InitialiseTo(int.MaxValue.ToString());
            }
            ForLoops[0] = ForLoops[0].WithStatement(constraint.Apply((IfStatementSyntax)ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }

        protected void Initialise()
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

        public void ConfigureWith(Function child)
        {
            Body = new List<StatementSyntax>
            {
                MicrosoftSyntaxFactory.ParseStatement($"A = {child.GetType().Name}(A);")
            }.
            Concat(Body).
            ToList();
        }
    }
}
