using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public static class RegisterSyntaxFactory
    {
        public static FieldDeclarationSyntax DeclareInt()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration("int register;");
        }

        public static FieldDeclarationSyntax DeclareBoolArray()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration("bool[] flags;");
        }

        public static FieldDeclarationSyntax DeclareIntArray()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration("int[] registers;");
        }

        public static StatementSyntax InitialiseBoolArray(string length)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"flags = new bool[{length}];");
        }

        public static StatementSyntax InitialiseIntArray(string length)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"registers = new int[{length}];");
        }

        public static StatementSyntax InitialiseToElementAt(int index)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"register = A[{index}];");
        }

        public static StatementSyntax InitialiseTo(int value)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"register = {value};");
        }

        public static StatementSyntax InitialiseToArrayLengthPlus(int value)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"register = A.Length + {value};");
        }
    }
}
