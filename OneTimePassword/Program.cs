using System;
using Newtonsoft.Json;

namespace OneTimePassword
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleManager.WriteMenu();
                Enum.TryParse(Console.ReadLine().ToLowerInvariant(), out Options option);

                if (option.Equals(Options.a))
                {
                    PasswordHandler.GeneratePasswordForUser();
                }
                else if (option.Equals(Options.b))
                {
                    PasswordHandler.CheckPasswordForUser();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
