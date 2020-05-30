using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Algocet.Functions
{
    public abstract class Function
    {
        public virtual MethodDeclarationSyntax Method { get; protected set; }
        public virtual List<FieldDeclarationSyntax> RegisterDeclarations { get; protected set; }
        public virtual List<StatementSyntax> Body { get; protected set; }

        protected virtual List<StatementSyntax> RegisterStatements { get; set; }
        protected virtual List<ForStatementSyntax> ForLoops { get; set; }
        protected virtual SyntaxProvider SyntaxProvider { get; set; }

        protected abstract void Initialise();
    }
}
