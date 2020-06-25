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

        private string FLAGS, REGISTER, REGISTERS;
        protected string FLAG_SNIPPET { get; set; }
        protected string SOLUTION_SNIPPET => $"if (!{FLAGS}[i]) {{ {REGISTERS}[{REGISTER}] = i{LOWER_BOUND.ToString()}; {REGISTER}++; }}";

        private List<ForStatementSyntax> forLoops;

        public Complement(int lowerBound = -1000000, int count = 2000001)
        {
            LOWER_BOUND = lowerBound;
            COUNT = count;
            InitialiseSyntaxProvider();

            FLAG_SNIPPET = $"{FLAGS}[A[i]+{-LOWER_BOUND}] = true;";

            Initialise();
        }

        public Complement(Constraint constraint, int lowerBound = -1000000, int count = 2000001)
        {
            LOWER_BOUND = lowerBound;
            COUNT = count;
            InitialiseSyntaxProvider();

            if (constraint.GetType() == typeof(PositiveConstraint))
            {
                FLAG_SNIPPET = $"{{ if (A[i] > 0 && !{FLAGS}[A[i]+1000000]) {{ {REGISTER}++; }} {FLAGS}[A[i]+{-LOWER_BOUND}] = true; }}";
                Initialise();

                RegisterStatements.RemoveAt(2);
                forLoops[1] = StatementSyntaxFactory.
                    CreateForLoop(-LOWER_BOUND + 1, $"< {FLAGS}.Length && {REGISTER} < {REGISTERS}.Length").
                    WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET));

                Body = RegisterStatements.Concat(new List<StatementSyntax>
                {
                    forLoops[0],
                    SyntaxProvider.InitialiseIntArray($"{(COUNT + LOWER_BOUND - 1).ToString()} - {REGISTER}"),
                    SyntaxProvider.InitialiseTo("0"),
                    forLoops[1]
                }).
                ToList();   
            }
            else
            {
                throw new NotSupportedException("Complement function does not support this constraint.");
            }
        }

        private void InitialiseSyntaxProvider()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);
            FLAGS = SyntaxProvider.FLAGS;
            REGISTER = SyntaxProvider.REGISTER;
            REGISTERS = SyntaxProvider.REGISTERS;
        }

        protected void Initialise()
        {
            Method = SyntaxProvider.CreateMethod("int[]", "int[] A", $"return {REGISTERS};");
            RegisterDeclarations = new List<FieldDeclarationSyntax>
            {
                SyntaxProvider.DeclareInt(),
                SyntaxProvider.DeclareBoolArray(),
                SyntaxProvider.DeclareIntArray()
            };
            RegisterStatements = new List<StatementSyntax>
            {
                SyntaxProvider.InitialiseTo("0"),
                SyntaxProvider.InitialiseBoolArray(COUNT.ToString()),
                SyntaxProvider.InitialiseIntArray($"{COUNT.ToString()} - A.Length")
            };
            forLoops = new List<ForStatementSyntax>
            {
                StatementSyntaxFactory.CreateForLoop(0).
                WithStatement(MicrosoftSyntaxFactory.ParseStatement(FLAG_SNIPPET)),
                StatementSyntaxFactory.CreateForLoop(0, $"< {FLAGS}.Length").
                WithStatement(MicrosoftSyntaxFactory.ParseStatement(SOLUTION_SNIPPET))
            };
            Body = RegisterStatements.
                Concat(forLoops).
                ToList();
        }
    }
}
