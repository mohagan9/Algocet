using Algocet.Condition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Rewriters
{
    public class BinaryConditionRewriter : CSharpSyntaxRewriter
    {
        private readonly BinaryCondition condition;

        public BinaryConditionRewriter(BinaryCondition condition)
        {
            this.condition = condition;
        }

        public override SyntaxNode VisitIfStatement(IfStatementSyntax ifStatement)
        {
            BinaryExpressionSyntax binaryExpression = MicrosoftSyntaxFactory.BinaryExpression(condition.Kind, ifStatement.Condition, condition.AdditionalExpression);
            return ifStatement.WithCondition(binaryExpression);
        }
    }
}
