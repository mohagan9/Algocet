using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class NestedFunction
    {
        public readonly Function Parent, Child;

        public NestedFunction(IParentFunction parent, Function child)
        {
            Child = child;

            RenameChildMethod();

            parent.ConfigureWith(Child);

            Parent = parent.Function;
        }

        private void RenameChildMethod()
        {
            Child.Method = (MethodDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration(
                            Child.Method.
                            GetText().ToString().
                            Replace("solution", Child.GetType().Name));
        }
    }
}
