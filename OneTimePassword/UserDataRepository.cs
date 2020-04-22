using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword
{
    public static class UserDataRepository
    {
        //This will simulate access to the DB.
        static UserDataRepository()
        {
            ActivePasswords = new List<string>();
        }

        private static List<string> ActivePasswords { get; set; }

        public static void AddPassword(string password)
        {
            ActivePasswords.Add(password);
        }

        public static void RemovePassword(string password)
        {
            ActivePasswords.Remove(password);
        }

        public static bool ExistsPassword(string password)
        {
            return ActivePasswords.Any(ap => ap == password);
        }
    }
}
