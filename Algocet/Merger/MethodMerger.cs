using Algocet.Functions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Merger
{
    public class MethodMerger
    {
        private readonly Function parent, child;

        public MethodMerger(Function parent, Function child)
        {
            this.parent = parent;
            this.child = child;
        }

        public MethodDeclarationSyntax Merge()
        {
            string matchingParentParamName = NameOfMatchingParentParameter(child.Method.ReturnType.GetType());

            if (matchingParentParamName is null)
            {
                return parent.Method;
            }

            return UpdateReturnStatementWithChildReturnVariable(matchingParentParamName).
                    WithParameterList(child.Method.ParameterList);
        }

        private string NameOfMatchingParentParameter(Type childReturnType)
        {
            return parent.Method.
                ParameterList.Parameters.
                FirstOrDefault(param => param.Type.GetType() == childReturnType)?.
                Identifier.ToString();
        }

        private MethodDeclarationSyntax UpdateReturnStatementWithChildReturnVariable(string variableToSwap)
        {
            return (MethodDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration(
                parent.Method.
                    ToString().
                    Replace(variableToSwap,
                        ((IdentifierNameSyntax)child.ReturnStatement.Expression).
                        ToString()));
        }
    }
}
