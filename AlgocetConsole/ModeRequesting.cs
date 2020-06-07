using System;
using System.Collections.Generic;

namespace AlgocetConsole
{
    public static class ModeRequesting
    {
        public static object GetMode(Type functionType, string mode)
        {
            return Enum.Parse(functionType.GetNestedType("Mode"), mode);
        }

        public static string[] GetModeOptions(Type functionType)
        {
            return Enum.GetNames(functionType.GetNestedType("Mode"));
        }
    }
}
