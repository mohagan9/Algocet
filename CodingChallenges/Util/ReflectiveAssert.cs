using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace CodingChallenges.Util
{
    public class ReflectiveAssert
    {
        public static void Throws<T>(Func<object> testCode) where T : Exception
        {
            try
            {
                testCode.Invoke();
            }
            catch (TargetInvocationException e)
            {
                Assert.Equal(typeof(T), e.InnerException.GetType());
                return;
            }
            throw new ThrowsException(typeof(T));
        }
    }
}
