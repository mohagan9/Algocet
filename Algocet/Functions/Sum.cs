using System.Collections.Generic;
using System.Linq;
using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Sum : Function, IParentFunction
    {
        protected string SOLUTION_SNIPPET => "registerSum += A[i];";

        public Function Function => this;
        private List<ForStatementSyntax> forLoops;

        public Sum()
        {
            Initialise();
        }

        public Sum(Constraint constraint)
        {
            Initialise();
            forLoops[0] = forLoops[0].WithStatement(MicrosoftSyntaxFactory.IfStatement(constraint.Expression, forLoops[0].Statement));
            Body = RegisterStatements.Concat(forLoops).ToList();
        }

        protected void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateDefaultMethod();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareInt() };
            RegisterStatements = new List<StatementSyntax> {
                StatementSyntaxFactory.CreateEmptyGuard(0),
                SyntaxProvider.InitialiseTo("0")
            };
            forLoops = new List<ForStatementSyntax>
                {
                    StatementSyntaxFactory.CreateForLoop(0).
                    WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET))
                };
            Body = RegisterStatements.
                Concat(forLoops).
                ToList();
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
