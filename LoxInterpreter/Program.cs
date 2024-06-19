using System;

namespace LoxInterpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: LoxInterpreter [script]");

                Environment.ExitCode = 64;

            }
            else if (args.Length == 1)
            {
                RunFile(args[0]);

            }
            else
            {
                RunPrompt();
            }
        }

        private static void RunPrompt()
        {
            throw new NotImplementedException();
        }

        private static void RunFile(string v)
        {
            throw new NotImplementedException();
        }
    }
}