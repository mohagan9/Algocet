using Algocet.Condition;
using Algocet.Rewriters;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Constraints
{
    public class NegativeConstraint : Constraint
    {
        protected override CSharpSyntaxRewriter CSharpSyntaxRewriter { get; }
        public override ExpressionSyntax Expression { get; }

        public NegativeConstraint()
        {
            Expression = MicrosoftSyntaxFactory.ParseExpression("A[i] < 0");
            BinaryCondition binaryCondition = new BinaryCondition(SyntaxKind.LogicalAndExpression, Expression);
            CSharpSyntaxRewriter = new BinaryConditionRewriter(binaryCondition);
        }
    }
}
