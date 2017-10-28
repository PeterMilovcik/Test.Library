using System;
using System.Reflection;

namespace GivenWhenThen.Extensions
{
    internal static class ActionExtensions
    {
        public static bool HasTestStepAttribute(this Action action)
        {
            return action.Method.GetCustomAttribute(typeof(TestStepAttribute)) as TestStepAttribute != null;
        }
    }
}