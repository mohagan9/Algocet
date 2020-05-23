using Algocet;
using Algocet.Functions;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace AlgocetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Code Challenge Cracker!");

            Function function = FunctionRequesting.Request();

            CSharpCompilation compilation = new SolutionCompiler()
                .Compile(new SolutionGenerator().Generate(function));

            SolutionPrinting.PrintToFile(compilation.SyntaxTrees[0]);
            Console.WriteLine("\nSolution saved to file.");
            while (true);
        }
    }
}