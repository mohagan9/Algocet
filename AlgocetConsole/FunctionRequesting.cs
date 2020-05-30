using Algocet.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace AlgocetConsole
{
    public static class FunctionRequesting
    {
        private static readonly Dictionary<string, Type> FUNCTION_MAP = new Dictionary<string, Type>
        {
            { "MAX", typeof(Max) },
            { "MIN", typeof(Min) },
            { "SUM", typeof(Sum) },
            { "UNPAIRED", typeof(Unpaired) },
            { "COMPLEMENT", typeof(Complement) }
        };

        public static Function Request()
        {
            string functionInput = RequestFunction();
            while (!FUNCTION_MAP.ContainsKey(functionInput))
            {
                Warnings.PrintInvalidInputMessage("function", FUNCTION_MAP.Keys);
                functionInput = RequestFunction();
            }
            var constraint = ConstraintRequesting.Request();
            if (constraint == null)
            {
                return CreateFunction(functionInput, new object[] { });
            }
            return CreateFunction(functionInput, new object[] { constraint });
        }

        private static string RequestFunction()
        {
            Console.WriteLine("\nEnter a function: ");
            return Console.ReadLine().ToUpper();
        }

        private static Function CreateFunction(string type, object[] constructorArgs)
        {
            return (Function)Activator.CreateInstance(FUNCTION_MAP[type],
                    BindingFlags.CreateInstance |
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.OptionalParamBinding, null, constructorArgs, CultureInfo.CurrentCulture);
        }
    }
}
