using System.Collections.Generic;
using System.Linq;
using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Sum : Function
    {
        protected string SOLUTION_SNIPPET => "registerSum += A[i];";

        public Sum()
        {
            Initialise();
        }

        public Sum(Constraint constraint)
        {
            Initialise();
            ForLoops[0] = ForLoops[0].WithStatement(MicrosoftSyntaxFactory.IfStatement(constraint.Expression, ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }

        protected override void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateDefaultMethod();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareInt() };
            RegisterStatements = new List<StatementSyntax> {
                StatementSyntaxFactory.CreateEmptyGuard(0),
                SyntaxProvider.InitialiseTo(0)
            };
            ForLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET))
            };
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
