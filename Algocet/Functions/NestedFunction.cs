using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class NestedFunction : Function
    {
        private readonly Function parent, child;

        public NestedFunction(Function parent, Function child)
        {
            this.parent = parent;
            this.child = child;
            Initialise();
        }

        protected override void Initialise()
        {
            Method = parent.Method;

            RegisterDeclarations = parent.RegisterDeclarations.
                Concat(child.RegisterDeclarations).
                ToList();
            
            Body = child.Body.
                Concat(ReplaceParentInputWithChildOutput()).
                ToList();
        }

        private List<StatementSyntax> ReplaceParentInputWithChildOutput()
        {
            var updatedStatements = new List<StatementSyntax>();
            foreach (StatementSyntax statement in parent.Body)
            {
                updatedStatements.Add(
                    MicrosoftSyntaxFactory.ParseStatement(
                        statement.GetText().
                        ToString().
                        Replace("A", 
                        ((IdentifierNameSyntax)
                        ((ReturnStatementSyntax)child.Method.Body.
                        Statements.First(s => s.GetType() == typeof(ReturnStatementSyntax))).
                        Expression).Identifier.Text)));
            }
            return updatedStatements;
        }
    }
}
