using Algocet.Functions;
using Algocet.Rewriters;
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

        public SyntaxTree Generate(NestedFunction function)
        {
            return Generate(new NestedSolutionRewriter(function));
        }

        public SyntaxTree Generate(Function function)
        {
            return Generate(new SolutionRewriter(function));
        }

        private SyntaxTree Generate(CSharpSyntaxRewriter rewriter)
        {
            var solution = (CSharpSyntaxNode)rewriter.Visit(TEMPLATE_TREE.GetRoot());
            return CSharpSyntaxTree.Create(solution);
        }
    }
}
