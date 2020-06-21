using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Count : Function
    {
        private const int CAPACITY = 2000001;

        public Count()
        {
            Initialise();
        }

        public void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateMethod("int", "int[] A, int subject", $"return registersCount[subject + {CAPACITY / 2}];");
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareIntArray() };
            ForLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(MicrosoftSyntaxFactory.ParseStatement($"registersCount[A[i] + {CAPACITY / 2}]++;"))
            };
            Body = new List<StatementSyntax>
            {
                SyntaxProvider.InitialiseIntArray(CAPACITY.ToString()),
                ForLoops[0]
            };
        }
    }
}
