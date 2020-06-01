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

        public static List<Function> Request()
        {
            var functions = new List<Function>();
            string[] functionInputs = RequestFunctions();
            foreach (string functionInput in functionInputs)
            {
                if (!FUNCTION_MAP.ContainsKey(functionInput))
                {
                    Warnings.PrintInvalidInputMessage("function", FUNCTION_MAP.Keys);
                    functionInputs = RequestFunctions();
                    functions = new List<Function>();
                }
                else
                {
                    functions.Add(CreateFunction(functionInput, new object[] { }));
                }
            }
            var constraint = ConstraintRequesting.Request();
            if (constraint != null)
            {
                int lastIndex = functions.Count - 1;
                functions[lastIndex] = CreateFunction(functionInputs[lastIndex], new object[] { constraint });
            }
            return functions;
        }

        private static string[] RequestFunctions()
        {
            Console.WriteLine("\nEnter one or two functions: ");
            return Console.ReadLine().ToUpper().Split(' ');
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
