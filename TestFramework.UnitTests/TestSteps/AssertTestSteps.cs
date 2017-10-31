using System;
using NUnit.Framework;
using TestFramework.TestCases;

namespace TestFramework.UnitTests.TestSteps
{
    public class AssertTestSteps
    {
        public Action IsNotNull(object obj)
        {
            return () => Assert.That(obj, Is.Not.Null);
        }
    }
}