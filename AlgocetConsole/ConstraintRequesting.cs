using Algocet.Constraints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace AlgocetConsole
{
    public static class ConstraintRequesting
    {
        private static readonly Dictionary<string, Type> constraintMap = new Dictionary<string, Type>
        {
            { "POSITIVE", typeof(PositiveConstraint) },
            { "NEGATIVE", typeof(NegativeConstraint) }
        };

        public static Constraint Request()
        {
            string constraintInput = RequestConstraint();
            if (constraintMap.ContainsKey(constraintInput))
            {
                return (Constraint)Activator.CreateInstance(constraintMap[constraintInput],
                    BindingFlags.CreateInstance |
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.OptionalParamBinding, null, new object[] { }, CultureInfo.CurrentCulture);
            }
            return null;
        }

        private static string RequestConstraint()
        {
            Console.WriteLine("\nEnter a constraint: ");
            return Console.ReadLine().ToUpper();
        }
    }
}
