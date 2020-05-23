using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Linq;

namespace Algocet
{
    public class SolutionCompiler
    {
        private readonly MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
            };

        public CSharpCompilation Compile(SyntaxTree solution)
        {
            return CSharpCompilation.Create(Path.GetRandomFileName(),
                new SyntaxTree[] { solution },
                references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }
    }
}
