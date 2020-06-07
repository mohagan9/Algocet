using Algocet;
using Algocet.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;

namespace AlgocetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Algocet: The Code Challenge Cracker!");

            List<Function> functions = FunctionRequesting.Request();

            SyntaxTree solutionTree;
            if (functions.Count == 1)
            {
                solutionTree = new SolutionGenerator().
                    Generate(functions[0]);
            }
            else
            {
                solutionTree = new SolutionGenerator().
                    Generate(new NestedFunction((IParentFunction)functions[0], functions[1]));
            }
                
            CSharpCompilation compilation = new SolutionCompiler()
                .Compile(solutionTree);

            SolutionPrinting.PrintToFile(compilation.SyntaxTrees[0]);
            Console.WriteLine("\nSolution saved to file.");
            while (true);
        }
    }
}