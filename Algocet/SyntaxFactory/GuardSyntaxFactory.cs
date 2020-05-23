using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public static class GuardSyntaxFactory
    {
        public static StatementSyntax CreateEmptyGuard(int returnValue)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"if (A.Length == 0) return {returnValue};");
        }
    }
}
