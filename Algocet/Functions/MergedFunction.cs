using Algocet.Constraints;
using Algocet.Merger;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace Algocet.Functions
{
    public class MergedFunction : Function
    {
        private readonly Function Parent, Child;
        
        public MergedFunction(Function parent, Function child)
        {
            Parent = parent;
            Child = child;

            Initialise();
        }

        public MergedFunction(Function parent, Function child, Constraint constraint)
        {
            Parent = parent;
            Child = child;

            Initialise();

            var forLoop = ForLoops[0];
            var forBlock = (BlockSyntax)forLoop.Statement;
            var ifStatement = forBlock.Statements.OfType<IfStatementSyntax>().First();
            forBlock = forBlock.ReplaceNode(ifStatement, constraint.Apply(ifStatement));
            
            Body[Body.IndexOf(forLoop)] = forLoop.WithStatement(forBlock);
        }

        protected void Initialise()
        {
            Method = new MethodMerger(Parent, Child).Merge();

            RegisterDeclarations = Parent.RegisterDeclarations.
                Concat(Child.RegisterDeclarations).
                ToList();

            RegisterStatements = Parent.RegisterStatements.
                Concat(Child.RegisterStatements).
                ToList();

            Body = new BodyMerger(Parent, Child, RegisterStatements).Merge();
        }
    }
}
