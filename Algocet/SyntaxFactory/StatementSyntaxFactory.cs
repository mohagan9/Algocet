using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public static class StatementSyntaxFactory
    {
        private static readonly CSharpParseOptions OPTIONS = CSharpParseOptions.Default.WithKind(SourceCodeKind.Script);

        public static ForStatementSyntax CreateForLoop(int startIndex)
        {
            return CreateForLoop(startIndex, "< A.Length");
        }

        public static ForStatementSyntax CreateForLoop(int startIndex, string condition)
        {
            return (ForStatementSyntax)MicrosoftSyntaxFactory.ParseStatement($"for (int i = {startIndex}; i {condition}; i++) {{ }}");
        }

        public static IfStatementSyntax CreateIfStatement(string snippet)
        {
            return (IfStatementSyntax)MicrosoftSyntaxFactory.ParseStatement(snippet);
        }

        public static ReturnStatementSyntax CreateReturnStatement(string snippet)
        {
            return (ReturnStatementSyntax)MicrosoftSyntaxFactory.ParseStatement(snippet);
        }

        public static StatementSyntax CreateEmptyGuard(int returnValue)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"if (A.Length == 0) return {returnValue};");
        }
    }
}
