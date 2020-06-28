using Algocet.Merger;
using Microsoft.CodeAnalysis;
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

            Method = new MethodMerger(parent, child).Merge();
            
            RegisterDeclarations = parent.RegisterDeclarations.
                Concat(child.RegisterDeclarations).
                ToList();

            RegisterStatements = parent.RegisterStatements.
                Concat(child.RegisterStatements).
                ToList();

            Body = new BodyMerger(parent, child, RegisterStatements).Merge();
        }
    }
}
