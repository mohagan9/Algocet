using Algocet;
using Algocet.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodingChallenges.Util
{
    public class ProblemSolution
    {
        private Type solverClass;
        private object solver;
        private CSharpCompilation compilation;

        public ProblemSolution(Function function)
        {
            LoadSolver(new SolutionGenerator().Generate(function));
        }

        public ProblemSolution(NestedFunction nestedFunction)
        {
            LoadSolver(new SolutionGenerator().Generate(nestedFunction));
        }

        private void LoadSolver(SyntaxTree syntaxTree)
        {
            compilation = new SolutionCompiler()
                .Compile(syntaxTree);

            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);
                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                }
                ms.Seek(0, SeekOrigin.Begin);

                solverClass = Assembly.Load(ms.ToArray()).GetType("Solution");
                solver = Activator.CreateInstance(solverClass);
            }
        }

        public int Solve(int[] A)
        {
            return (int)solverClass.InvokeMember("solution",
                BindingFlags.InvokeMethod,
                null,
                solver,
                new object[] { A });
        }

        public int[] SolveAsArray(int[] A)
        {
            return (int[])solverClass.InvokeMember("solution",
                BindingFlags.InvokeMethod,
                null,
                solver,
                new object[] { A });
        }
    }
}
