using Microsoft.CodeAnalysis;
using System.IO;

namespace AlgocetConsole
{
    public static class SolutionPrinting
    {
        public static void PrintToFile(SyntaxTree syntaxTree)
        {
            StreamWriter sw = new StreamWriter("solution.txt");
            string formattedSolution = NewlineKeywords(syntaxTree.GetText().ToString()).
                Replace("{", "\n{\n").
                Replace("}", "\n}\n");

            sw.WriteLine(formattedSolution);
            sw.Close();
        }

        private static string NewlineKeywords(string solution)
        {
            return solution.
                Replace("public", "\npublic").
                Replace("for", "\nfor").
                Replace("if", "\nif");
        }
    }
}
