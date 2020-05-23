using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Algocet.Condition
{
    public class BinaryCondition
    {
        public readonly SyntaxKind Kind;
        public readonly ExpressionSyntax AdditionalExpression;

        public BinaryCondition(SyntaxKind kind, ExpressionSyntax additionalExpression)
        {
            Kind = kind;
            AdditionalExpression = additionalExpression;
        }
    }
}
