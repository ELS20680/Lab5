using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Versioning;

namespace Lab5_ExceptionHandling
{
    class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int result = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    a = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter second number: ");
                    b = Convert.ToInt32(Console.ReadLine());

                    result = a / b;
                    File.WriteAllText("result.txt", $"Result: {result}");
                    Console.WriteLine($"Result: {result}");
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter valid integers.");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero.");
                }
            }

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
