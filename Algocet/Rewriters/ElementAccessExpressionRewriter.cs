using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Rewriters
{
    public class ElementAccessExpressionRewriter : CSharpSyntaxRewriter
    {
        private readonly ElementAccessExpressionSyntax newElementAccessExpression;

        public ElementAccessExpressionRewriter(ElementAccessExpressionSyntax newElementAccessExpression)
        {
            this.newElementAccessExpression = newElementAccessExpression;
        }
        
        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            string leftIdentifier = ((ElementAccessExpressionSyntax)node.Left).ToString();
            string rightIdentifier = ((IdentifierNameSyntax)node.Right).Identifier.ToString();
            ExpressionSyntax rightElementAccessExpression = MicrosoftSyntaxFactory.ParseExpression(
                newElementAccessExpression.
                ToString().
                Replace(leftIdentifier, rightIdentifier));

            return node.
                WithLeft(newElementAccessExpression).
                WithRight(rightElementAccessExpression);
        }
    }
}
