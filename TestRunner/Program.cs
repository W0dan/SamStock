using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ObviousCode.TestRunner;
using Tests.Concerning_Stock.GetStockOverzicht.Given_a_GetStockOverzichtHandler;

namespace TestRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var testAssembly = Assembly.GetAssembly(typeof (When_Handle_is_called));

            var q = from t in testAssembly.GetTypes()
                    where t.IsClass
                    select t;
            q.ToList();

            foreach (var type in q)
            {
                RunTests<>();
            }

            RunTests();
        }

        private static void RunTests<T>()
        {
            TestResults results = Tester.RunTestsInClass<T>();

            Console.WriteLine("Tests Run: {0}", results.NumberOfResults);
            Console.WriteLine("Results {0}:PASSED {1}:FAILED", results.NumberOfPasses, results.NumberOfFails);
            Console.WriteLine("Details:");

            foreach (TestResult result in results)
            {
                Console.WriteLine("Test {0}: {1} {2}",
                                  result.MethodName,
                                  result.Result,
                                  result.Result == TestResult.Outcome.Fail ? "\r\n" + result.Message : "");
            }

            Console.ReadLine();
        }
    }
}
