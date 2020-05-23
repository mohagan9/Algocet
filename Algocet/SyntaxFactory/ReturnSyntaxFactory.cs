using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public static class ReturnSyntaxFactory
    {
        public static ReturnStatementSyntax CreateDefault()
        {
            return (ReturnStatementSyntax)MicrosoftSyntaxFactory.ParseStatement("return register;");
        }

        public static ReturnStatementSyntax Create(string snippet)
        {
            return (ReturnStatementSyntax)MicrosoftSyntaxFactory.ParseStatement(snippet);
        }
    }
}
