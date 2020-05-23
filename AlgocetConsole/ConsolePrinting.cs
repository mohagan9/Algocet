using System;
using System.Collections.Generic;

namespace AlgocetConsole
{
    public static class ConsolePrinting
    {
        public static void PrintInvalidInputMessage(string type, IEnumerable<string> validCollection)
        {
            Console.WriteLine($"\nInvalid {type} entered. Must be one of the following:");
            foreach (string valid in validCollection)
            {
                Console.WriteLine($"\t- {valid}");
            }
        }
    }
}
