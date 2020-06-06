using Algocet.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Algocet.Functions
{
    public class Check : Function, IParentFunction
    {
        public Function Function => this;

        public enum Mode
        {
            DEFAULT, NOT
        }
        private readonly string comparison = "!=";

        public Check(Mode mode = Mode.DEFAULT)
        {
            if (mode == Mode.NOT)
            {
                comparison = "==";
            }
        }

        public void ConfigureWith(Function child)
        {
            SyntaxProvider = new SyntaxProvider("Check");
            
            RegisterDeclarations = new List<FieldDeclarationSyntax>
            {
                SyntaxProvider.DeclareInt()
            };
            Body = new List<StatementSyntax>
            {
                SyntaxProvider.InitialiseTo(GetInitialValueOfChildRegister(child))
            };
            Method = SyntaxProvider.CreateMethod("int", "int[] A", $"return { child.GetType().Name} (A) {comparison} registerCheck ? 1 : 0;");
        }

        private string GetInitialValueOfChildRegister(Function child)
        {
            string childRegisterName = ((IdentifierNameSyntax)child.ReturnStatement.Expression).
                Identifier.Text;

            return child.Body.
                OfType<ExpressionStatementSyntax>().
                Select(exp => exp.Expression).
                OfType<AssignmentExpressionSyntax>().
                First(assign => assign.Left.ToString() == childRegisterName).
                Right.ToString();
        }
    }
}
