using Algocet.Condition;
using Algocet.Rewriters;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Constraints
{
    public class PositiveConstraint : Constraint
    {
        protected override CSharpSyntaxRewriter CSharpSyntaxRewriter { get; }
        public override ExpressionSyntax Expression { get; }

        public PositiveConstraint(string valueExpression = "A[i]")
        {
            Expression = MicrosoftSyntaxFactory.ParseExpression($"{valueExpression} > 0");
            BinaryCondition binaryCondition = new BinaryCondition(SyntaxKind.LogicalAndExpression, Expression);
            CSharpSyntaxRewriter = new BinaryConditionRewriter(binaryCondition);
        }
    }
}
