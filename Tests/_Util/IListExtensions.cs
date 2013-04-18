using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using SamStock.Web._Interfaces;

namespace Tests._Util
{
    public static class IListExtensions
    {
        public static void ShouldMatchAllItemsOf<TExpected, TActual>(this IList<TActual> response, IList<TExpected> expectedResult, Func<TExpected, TActual, bool> isMatch)
        {
            if (expectedResult.Count() != response.Count())
                Assert.Fail("Expected {0}, Actual {1} items", expectedResult.Count(), response.Count());

            if (expectedResult.Any(item => response.All(x => !isMatch(item, x))))
                Assert.Fail("Not all items match");
        }
    }
}