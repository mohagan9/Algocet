using Algocet.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Algocet
{
    public class SolutionGenerator
    {
        private const string CLASS_TEMPLATE = "public class Solution { }";
        private readonly SyntaxTree TEMPLATE_TREE;

        public SolutionGenerator()
        {
            TEMPLATE_TREE = CSharpSyntaxTree.ParseText(CLASS_TEMPLATE);
        }

        public SyntaxTree Generate(Function function)
        {
            SolutionRewriter solutionRewriter = new SolutionRewriter(function);
            CSharpSyntaxNode solution = (CSharpSyntaxNode)solutionRewriter.Visit(TEMPLATE_TREE.GetRoot());
            return CSharpSyntaxTree.Create(solution);
        }
    }
}
