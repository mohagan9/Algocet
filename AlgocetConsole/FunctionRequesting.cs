using Algocet.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            { "COMPLEMENT", typeof(Complement) },
            { "CHECK", typeof(Check) }
        };

        public static List<Function> Request()
        {
            var functions = new List<Function>();
            IEnumerable<string[]> functionInputs = RequestFunctions();
                
            foreach (string[] functionInput in functionInputs)
            {
                string functionName = functionInput.Last();

                if (!FUNCTION_MAP.ContainsKey(functionName))
                {
                    Warnings.PrintInvalidInputMessage("function", FUNCTION_MAP.Keys);
                    return Request();
                }
                else if (functionInput.Length == 1)
                {
                    functions.Add(CreateFunction(functionName, new object[] { }));
                }
                else
                {
                    object mode = null;
                    try
                    {
                        mode = ModeRequesting.GetMode(FUNCTION_MAP[functionName], functionInput[0]);
                    }
                    catch (ArgumentException e)
                    {
                        Warnings.PrintInvalidInputMessage("mode", ModeRequesting.GetModeOptions(FUNCTION_MAP[functionName]));
                        return Request();
                    }
                    functions.Add(CreateFunction(functionName, new object[] { mode }));
                }
            }
            var constraint = ConstraintRequesting.Request();
            if (constraint != null)
            {
                int lastIndex = functions.Count - 1;
                string lastFunctionName = functions[lastIndex].GetType().Name.ToUpper();
                functions[lastIndex] = CreateFunction(lastFunctionName, new object[] { constraint });
            }
            return functions;
        }

        private static IEnumerable<string[]> RequestFunctions()
        {
            Console.WriteLine("\nEnter one or two functions: ");
            return Console.ReadLine().
                ToUpper().
                Split(' ').
                Select(input => input.Split("_"));
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
