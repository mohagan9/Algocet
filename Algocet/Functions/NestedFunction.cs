using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class NestedFunction
    {
        public readonly Function Parent, Child;

        public NestedFunction(Function parent, Function child)
        {
            Parent = parent;
            Child = child;

            RenameChildMethod();

            Parent.Body = new List<StatementSyntax>
            {
                MicrosoftSyntaxFactory.ParseStatement($"A = {Child.GetType().Name}(A);")
            }.
            Concat(Parent.Body).
            ToList();
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
