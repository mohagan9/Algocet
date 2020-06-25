using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class MergedFunction : Function
    {
        private readonly Function Parent, Child;
        
        public MergedFunction(Function parent, Function child)
        {
            Parent = parent;
            Child = child;

            Method = MergeMethods(
                GetParentInputName(child.Method.ReturnType.GetType()));

            RegisterDeclarations = parent.RegisterDeclarations.
                Concat(child.RegisterDeclarations).
                ToList();

            RegisterStatements = parent.RegisterStatements.
                Concat(child.RegisterStatements).
                ToList();

            Body = RegisterStatements.
                Concat(new List<StatementSyntax>
                {
                    parent.ForLoops[0].
                    WithStatement(MicrosoftSyntaxFactory.Block(
                        parent.ForLoops[0].Statement,
                        child.ForLoops[0].Statement))
                }).
                ToList();
        }

        private string GetParentInputName(Type childReturnType)
        {
            return Parent.Method.
                ParameterList.Parameters.
                First(param => param.Type.GetType() == childReturnType).
                Identifier.ToString();
        }
        
        private MethodDeclarationSyntax MergeMethods(string parentInputName)
        {
            string parentMethodWithUpdatedReturnStatement = Parent.Method.
                    ToString().
                    Replace(parentInputName,
                        ((IdentifierNameSyntax)Child.ReturnStatement.Expression).ToString());

            return ((MethodDeclarationSyntax)MicrosoftSyntaxFactory.ParseMemberDeclaration(parentMethodWithUpdatedReturnStatement)).
                WithParameterList(Child.Method.ParameterList);
        }
    }
}
