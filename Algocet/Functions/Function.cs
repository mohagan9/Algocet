using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Algocet.Functions
{
    public abstract class Function
    {
        public MethodDeclarationSyntax Method { get; set; }
        public List<FieldDeclarationSyntax> RegisterDeclarations { get; protected set; }
        public List<StatementSyntax> Body { get; set; }
        public List<StatementSyntax> RegisterStatements { get; set; }

        public List<ForStatementSyntax> ForLoops
        {
            get
            {
                return Body.AsEnumerable().
                    OfType<ForStatementSyntax>()
                    .ToList();
            }
        }

        protected SyntaxProvider SyntaxProvider { get; set; }

        public ReturnStatementSyntax ReturnStatement => 
            Method.Body.
            Statements.AsEnumerable().
            OfType<ReturnStatementSyntax>().
            Last();
   
    }
}
