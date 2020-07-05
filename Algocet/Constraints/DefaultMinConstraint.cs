using Algocet.Condition;
using Algocet.Rewriters;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Constraints
{
    public class DefaultMinConstraint : Constraint
    {
        public DefaultMinConstraint()
        {
        }

        public override IfStatementSyntax Apply(IfStatementSyntax solutionStatement)
        {
            var minExpression = MicrosoftSyntaxFactory.ParseExpression("A[i] < registerMax");
            var solutionCondition = (BinaryExpressionSyntax)solutionStatement.Condition;
            var tieExpression = MicrosoftSyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, solutionCondition.Left, solutionCondition.Right);

            Expression = MicrosoftSyntaxFactory.BinaryExpression(
                SyntaxKind.LogicalAndExpression,
                tieExpression, minExpression);

            BinaryCondition binaryCondition = new BinaryCondition(SyntaxKind.LogicalOrExpression, Expression);
            CSharpSyntaxRewriter = new BinaryConditionRewriter(binaryCondition);

            return base.Apply(solutionStatement);
        }
    }
}
