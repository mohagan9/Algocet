﻿using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Max : Function, IParentFunction
    {
        protected string SOLUTION_SNIPPET => "if (A[i] > registerMax) { registerMax = A[i]; }";

        public Function Function => this;
        private List<ForStatementSyntax> forLoops;

        public Max()
        {
            Initialise();
        }

        public Max (Constraint constraint)
        {
            Initialise();
            
            if (constraint.GetType() == typeof(NegativeConstraint))
            {
                RegisterStatements[0] = SyntaxProvider.InitialiseTo(int.MinValue.ToString());
            }
            forLoops[0] = forLoops[0].WithStatement(constraint.Apply((IfStatementSyntax)forLoops[0].Statement));
            Body = RegisterStatements.Concat(forLoops).ToList();
        }

        protected void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateDefaultMethod();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareInt() };
            RegisterStatements = new List<StatementSyntax> { SyntaxProvider.InitialiseToElementAt(0) };

            forLoops = new List<ForStatementSyntax>
                {
                    StatementSyntaxFactory.CreateForLoop(0).
                    WithStatement(StatementSyntaxFactory.CreateIfStatement(SOLUTION_SNIPPET))
                };
            Body = RegisterStatements.
                Concat(forLoops).
                ToList();
        }

        public void ConfigureWith(Function child)
        {
            Body = new List<StatementSyntax>
            {
                MicrosoftSyntaxFactory.ParseStatement($"A = {child.GetType().Name}(A);")
            }.
            Concat(Body).
            ToList();
        }
    }
}
