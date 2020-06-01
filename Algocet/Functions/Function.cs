using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Algocet.Functions
{
    public abstract class Function
    {
        public MethodDeclarationSyntax Method { get; set; }
        public List<FieldDeclarationSyntax> RegisterDeclarations { get; protected set; }
        public List<StatementSyntax> Body { get; set; }

        protected List<StatementSyntax> RegisterStatements { get; set; }
        protected List<ForStatementSyntax> ForLoops { get; set; }
        protected SyntaxProvider SyntaxProvider { get; set; }

        protected abstract void Initialise();
    }
}
