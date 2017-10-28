using System;

namespace GivenWhenThen.Extensions
{
    internal static class ObjectExtensions
    {
        public static void IfNotNull(this object obj, Action action)
        {
            if (obj != null) action.Invoke();
        }
    }
}