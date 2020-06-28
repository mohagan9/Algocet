using Algocet.Functions;
using Algocet.Rewriters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Merger
{
    public class BodyMerger
    {
        private readonly Function parent, child;
        private readonly List<StatementSyntax> registerStatements;

        public BodyMerger(Function parent, Function child, List<StatementSyntax> registerStatements)
        {
            this.parent = parent;
            this.child = child;
            this.registerStatements = registerStatements;
        }

        public List<StatementSyntax> Merge()
        {
            string matchingChildRegisterName = NameOfMatchingChildRegister(
                parent.Method.
                ParameterList.Parameters[0].
                Type.GetType());
            
            if (matchingChildRegisterName is null)
            {
                return registerStatements.
                Concat(new List<StatementSyntax>
                {
                    parent.ForLoops[0].
                    WithStatement(MicrosoftSyntaxFactory.Block(
                        child.ForLoops[0].Statement,
                        parent.ForLoops[0].Statement))
                }).
                ToList();
            }

            var childElementAccessExpression = child.
                ForLoops[0].
                Statement.
                DescendantNodes().OfType<ElementAccessExpressionSyntax>().
                First();

            var elementAccessExpressionRewriter = new ElementAccessExpressionRewriter(childElementAccessExpression);
            
            return registerStatements.
                Concat(new List<StatementSyntax>
                {
                    parent.ForLoops[0].
                    WithStatement(MicrosoftSyntaxFactory.Block(
                        child.ForLoops[0].Statement,
                        (StatementSyntax)elementAccessExpressionRewriter.
                        Visit(parent.ForLoops[0].Statement)))
                }).
                ToList();
        }

        private string NameOfMatchingChildRegister(Type parentParamType)
        {
            return child.RegisterDeclarations.
                FirstOrDefault(reg => reg.Declaration.Type.GetType() == parentParamType)?.
                Declaration.Variables[0].
                Identifier.ToString();
        }
    }
}
