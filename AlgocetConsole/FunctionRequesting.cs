using Algocet.Functions;
using System;
using System.Collections.Generic;

namespace AlgocetConsole
{
    public static class FunctionRequesting
    {
        private static readonly Dictionary<string, Type> functionMap = new Dictionary<string, Type>
        {
            { "MAX", typeof(Max) },
            { "MIN", typeof(Min) },
            { "SUM", typeof(Sum) },
            { "UNPAIRED", typeof(Unpaired) }
        };

        public static Function Request()
        {
            string functionInput = RequestFunction();
            while (!functionMap.ContainsKey(functionInput))
            {
                ConsolePrinting.PrintInvalidInputMessage("function", functionMap.Keys);
                functionInput = RequestFunction();
            }
            var constraint = ConstraintRequesting.Request();
            return (Function)Activator.CreateInstance(functionMap[functionInput], new[] { constraint }); ;
        }

        private static string RequestFunction()
        {
            Console.WriteLine("\nEnter a function: ");
            return Console.ReadLine().ToUpper();
        }
    }
}
