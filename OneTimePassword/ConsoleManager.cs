using System;

namespace OneTimePassword
{
    public static class ConsoleManager
    {
        public static void WriteMenu()
        {
            Console.WriteLine("Select A) for generating a new password,  B) for checking a password or anything else) to exit:");
        }

        public static UserData ReadUserData()
        {
            Console.WriteLine("Please Provide User Id");
            int.TryParse(Console.ReadLine(), out var userId);

            Console.WriteLine("Please Provide Date");
            DateTime.TryParse(Console.ReadLine(), out var userDate);

            return new UserData(userId, userDate);
        }

        public static string ReadUserPassword()
        {
            Console.WriteLine("Please provide the password");
            return Console.ReadLine();
        }

        public static void WriteBadData()
        {
            Console.WriteLine("Provided data is incorrect");
        }

        public static void WritePassword(string password)
        {
            Console.WriteLine($"Your password is : {password}");
        }
    }
}
