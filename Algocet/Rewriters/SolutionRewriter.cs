using Algocet.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Algocet
{
    class SolutionRewriter : CSharpSyntaxRewriter
    {
        private readonly Function function;

        public SolutionRewriter(Function function)
        {
            this.function = function;
        }
        
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            MemberDeclarationSyntax[] members = function.
                RegisterDeclarations.Cast<MemberDeclarationSyntax>().
                Concat(
                new List<MemberDeclarationSyntax>
                {
                    function.Method.
                    WithBody((BlockSyntax)VisitBlock(function.Method.Body))
                }).
                ToArray();

            return node.AddMembers(members);
        }

        public override SyntaxNode VisitBlock(BlockSyntax block)
        {
            return block.Parent.GetType() == typeof(MethodDeclarationSyntax) ?
                block.WithStatements(new SyntaxList<StatementSyntax>(
                    function.Body.
                    Concat(block.Statements))) : block;
        }
    }
}
