using System.Collections.Generic;
using System.Linq;
using System;
using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Complement : Function
    {
        private readonly int LOWER_BOUND;
        private readonly int COUNT;

        protected string FLAG_SNIPPET { get; set; }
        protected override string SOLUTION_SNIPPET => $"if (!flags[i]) {{ registers[register] = i{LOWER_BOUND.ToString()}; register++; }}";

        public Complement(int lowerBound = -1000000, int count = 2000001)
        {
            LOWER_BOUND = lowerBound;
            COUNT = count;
            FLAG_SNIPPET = $"flags[A[i]+{-LOWER_BOUND}] = true;";

            Initialise();
        }

        public Complement(Constraint constraint, int lowerBound = -1000000, int count = 2000001)
        {
            LOWER_BOUND = lowerBound;
            COUNT = count;

            if (constraint.GetType() == typeof(PositiveConstraint))
            {
                FLAG_SNIPPET = $"{{ if (A[i] > 0 && !flags[A[i]+1000000]) {{ register++; }} flags[A[i]+{-LOWER_BOUND}] = true; }}";
                Initialise();

                RegisterStatements.RemoveAt(2);
                ForLoops[1] = StatementSyntaxFactory.
                    CreateForLoop(-LOWER_BOUND + 1, "< flags.Length && register < registers.Length").
                    WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET));

                Body = RegisterStatements.Concat(new List<StatementSyntax>
                {
                    ForLoops[0],
                    RegisterSyntaxFactory.InitialiseIntArray($"{(COUNT + LOWER_BOUND - 1).ToString()} - register"),
                    RegisterSyntaxFactory.InitialiseTo(0),
                    ForLoops[1]
                }).
                ToList();   
            }
            else
            {
                throw new NotSupportedException("Complement function does not support this constraint.");
            }
        }

        protected override void Initialise()
        {
            Method = MethodSyntaxFactory.Create("int[]", "int[] A", "registers");
            RegisterDeclarations = new List<FieldDeclarationSyntax>
            {
                RegisterSyntaxFactory.DeclareInt(),
                RegisterSyntaxFactory.DeclareBoolArray(),
                RegisterSyntaxFactory.DeclareIntArray()
            };
            RegisterStatements = new List<StatementSyntax>
            {
                RegisterSyntaxFactory.InitialiseTo(0),
                RegisterSyntaxFactory.InitialiseBoolArray(COUNT.ToString()),
                RegisterSyntaxFactory.InitialiseIntArray($"{COUNT.ToString()} - A.Length")
            };
            ForLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(MicrosoftSyntaxFactory.ParseStatement(FLAG_SNIPPET)),
                StatementSyntaxFactory.CreateForLoop(0, "< flags.Length").
                WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET))
            };
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
