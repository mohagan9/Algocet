using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Algocet.Constraints
{
    public abstract class Constraint
    {
        protected abstract CSharpSyntaxRewriter CSharpSyntaxRewriter { get; }
        public abstract ExpressionSyntax Expression { get; }

        public virtual IfStatementSyntax Apply(IfStatementSyntax solutionStatement)
        {
            return (IfStatementSyntax)CSharpSyntaxRewriter.VisitIfStatement(solutionStatement);
        }
    }
}
