using System;

namespace LoxInterpreter
{
    internal class Program
    {
        static bool hadError = false;

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
            for (;;)
            {
                Console.Write("> ");
                string line = Console.ReadLine();

                if (line == null)
                {
                    break;
                }

                Run(line);
            }
        }

        private static void RunFile(string path)
        {
            string sourceCode = File.ReadAllText(path);
            Run(sourceCode);

            if (hadError)
            {
                Environment.Exit(65);
            }
        }

        private static void Run(string sourceCode)
        {
            Scanner scanner = new Scanner(sourceCode);
            List<Token> tokens = scanner.ScanTokens();

            foreach (Token token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }

        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        public static void Report(int line, string where, string message)
        {
            Console.Error.WriteLine($"[line {line}] Error {where}: {message}");
            hadError = true;
        }
    }
}