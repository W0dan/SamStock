using System;
using System.Linq;
using System.Reflection;
using ObviousCode.TestRunner;
using Tests;

namespace TestRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfTests = 0;
            var numberOfPassedTests = 0;
            var numberOfFailedTests = 0;

            var testAssembly = Assembly.GetAssembly(typeof(BaseTest));

            var q = from t in testAssembly.GetTypes()
                    where t.IsClass
                    select t;
            q.ToList();

            var previousNamespaces = "";

            foreach (var type in q)
            {
                object instance = null;
                try
                {
                    instance = Activator.CreateInstance(type);
                }
                catch (Exception)
                {
                }
                if (instance != null)
                {
                    if (type.Namespace != previousNamespaces)
                    {
                        previousNamespaces = type.Namespace;
                        var namespaces = type.Namespace.Split('.');
                        Console.WriteLine(namespaces.Last());
                        if (namespaces.Last().EndsWith("Executor"))
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("  It is not possible to run databasetests test for now");
                            Console.ResetColor();
                            continue;
                        }
                    }

                    var result = RunTests(instance);
                    numberOfTests += result.NumberOfResults;
                    numberOfPassedTests += result.NumberOfPasses;
                    numberOfFailedTests += result.NumberOfFails;
                }
            }

            if (numberOfFailedTests > 0)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (numberOfPassedTests > 0)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Tests Run: {0}", numberOfTests);
            Console.WriteLine("Passed: {0}", numberOfPassedTests);
            Console.WriteLine("Failed: {0}", numberOfFailedTests);
            Console.ResetColor();

            Console.ReadLine();
        }

        private static TestResults RunTests(object testClass)
        {
            var results = Tester.RunTestsInClass(testClass);

            if (results.NumberOfResults == 0)
            {
                //Console.WriteLine("class " + testClass.GetType().Name + " has no tests");
                return results;
            }

            var type = testClass.GetType();
            Console.WriteLine("  " + type.Name);

            foreach (var result in results)
            {
                Console.WriteLine("    {0}: {1}",
                                  result.MethodName.Split('.')[1],
                                  result.Result);
                if (result.Result == TestResult.Outcome.Fail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("      " + result.Message);
                    Console.ResetColor();
                }
            }

            return results;
        }
    }
}
