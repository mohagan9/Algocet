using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.SyntaxFactory
{
    public static class MethodSyntaxFactory
    {
        public static MethodDeclarationSyntax CreateDefault()
        {
            return Create("int", "int[] A", "register");
        }

        public static MethodDeclarationSyntax Create(string returnType, string parameters, string returnVariable)
        {
            return (MethodDeclarationSyntax)MicrosoftSyntaxFactory.
                ParseMemberDeclaration($"public {returnType} solution({parameters}) {{ return {returnVariable}; }}");
        }
    }
}
