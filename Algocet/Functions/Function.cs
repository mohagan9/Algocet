using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algocet.Functions
{
    public abstract class Function
    {
        protected virtual string SOLUTION_SNIPPET => throw new NotImplementedException();

        public virtual MethodDeclarationSyntax Method { get; protected set; }
        public virtual List<FieldDeclarationSyntax> RegisterDeclarations { get; protected set; }
        public virtual List<StatementSyntax> Body { get; protected set; }

        protected virtual List<StatementSyntax> RegisterStatements { get; set; }
        protected virtual List<ForStatementSyntax> ForLoops { get; set; }

        protected virtual void Initialise()
        {
            Method = MethodSyntaxFactory.CreateDefault();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { RegisterSyntaxFactory.DeclareInt()};
            RegisterStatements = new List<StatementSyntax> { RegisterSyntaxFactory.InitialiseToElementAt(0) };
            ForLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(StatementSyntaxFactory.CreateIfStatement(SOLUTION_SNIPPET))
            };
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
