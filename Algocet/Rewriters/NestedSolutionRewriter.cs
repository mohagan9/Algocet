using Algocet.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Algocet.Rewriters
{
    public class NestedSolutionRewriter : CSharpSyntaxRewriter
    {
        private readonly NestedFunction nestedFunction;
        private readonly SolutionRewriter parentSolutionRewriter;
        private readonly SolutionRewriter childSolutionRewriter;

        public NestedSolutionRewriter(NestedFunction nestedFunction)
        {
            this.nestedFunction = nestedFunction;
            parentSolutionRewriter = new SolutionRewriter(nestedFunction.Parent);
            childSolutionRewriter = new SolutionRewriter(nestedFunction.Child);
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node = (ClassDeclarationSyntax)parentSolutionRewriter.VisitClassDeclaration(node);
            return childSolutionRewriter.VisitClassDeclaration(node);
        }
    }
}
