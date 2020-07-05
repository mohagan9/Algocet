using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Algocet.Constraints
{
    public abstract class Constraint
    {
        protected CSharpSyntaxRewriter CSharpSyntaxRewriter { get; set; }
        public ExpressionSyntax Expression { get; protected set; }

        public virtual IfStatementSyntax Apply(IfStatementSyntax solutionStatement)
        {
            return (IfStatementSyntax)CSharpSyntaxRewriter.VisitIfStatement(solutionStatement);
        }
    }
}
