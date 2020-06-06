using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public class SyntaxProvider
    {
        public readonly string REGISTER, REGISTERS, FLAGS;

        public SyntaxProvider(string functionName)
        {
            REGISTER = $"register{functionName}";
            REGISTERS = $"registers{functionName}";
            FLAGS = $"flags{functionName}";
        }

        public FieldDeclarationSyntax DeclareInt()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration($"int {REGISTER};");
        }

        public FieldDeclarationSyntax DeclareBoolArray()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration($"bool[] {FLAGS};");
        }

        public FieldDeclarationSyntax DeclareIntArray()
        {
            return (FieldDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration($"int[] {REGISTERS};");
        }

        public StatementSyntax InitialiseBoolArray(string length)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"{FLAGS} = new bool[{length}];");
        }

        public StatementSyntax InitialiseIntArray(string length)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"{REGISTERS} = new int[{length}];");
        }

        public StatementSyntax InitialiseToElementAt(int index)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"{REGISTER} = A[{index}];");
        }

        public StatementSyntax InitialiseTo(string value)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"{REGISTER} = {value};");
        }

        public StatementSyntax InitialiseToArrayLengthPlus(int value)
        {
            return MicrosoftSyntaxFactory.ParseStatement($"{REGISTER} = A.Length + {value};");
        }

        public MethodDeclarationSyntax CreateDefaultMethod()
        {
            return CreateMethod("int", "int[] A", $"return {REGISTER};");
        }

        public MethodDeclarationSyntax CreateMethod(string returnType, string parameters, string returnStatement)
        {
            return (MethodDeclarationSyntax)MicrosoftSyntaxFactory.
                ParseMemberDeclaration($"public {returnType} solution({parameters}) {{ {returnStatement} }}");
        }
    }
}
