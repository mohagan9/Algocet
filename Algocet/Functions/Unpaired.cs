﻿using Algocet.Constraints;
using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using MicrosoftSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algocet.Functions
{
    public class Unpaired : Function
    {
        public enum Mode
        {
            DEFAULT, NATURAL
        }
        private readonly Mode mode;

        public Unpaired(Mode mode = Mode.DEFAULT)
        {
            this.mode = mode;
            Initialise();
        }

        public Unpaired(Constraint constraint, Mode mode = Mode.DEFAULT)
        {
            this.mode = mode;
            Initialise();
            ForLoops[0] = ForLoops[0].WithStatement(MicrosoftSyntaxFactory.IfStatement(constraint.Expression, ForLoops[0].Statement));
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }

        protected void Initialise()
        {
            SyntaxProvider = new SyntaxProvider(GetType().Name);

            Method = SyntaxProvider.CreateDefaultMethod();
            RegisterDeclarations = new List<FieldDeclarationSyntax> { SyntaxProvider.DeclareInt() };
            if (mode == Mode.NATURAL)
            {
                RegisterStatements = new List<StatementSyntax> { SyntaxProvider.InitialiseToArrayLengthPlus(1) };
                ForLoops = new List<ForStatementSyntax>
                {
                    StatementSyntaxFactory.CreateForLoop(0).
                    WithStatement(MicrosoftSyntaxFactory.ParseStatement($"{SyntaxProvider.REGISTER} ^= (A[i] ^ (i+1));"))
                };
            }
            else
            {
                RegisterStatements = new List<StatementSyntax> { SyntaxProvider.InitialiseTo("0") };
                ForLoops = new List<ForStatementSyntax>
                {
                    StatementSyntaxFactory.CreateForLoop(0).
                    WithStatement(MicrosoftSyntaxFactory.ParseStatement($"{SyntaxProvider.REGISTER} ^= A[i];"))
                };
            }
            Body = RegisterStatements.Concat(ForLoops).ToList();
        }
    }
}
