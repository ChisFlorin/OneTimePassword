using System;
using Newtonsoft.Json;

namespace OneTimePassword
{
    public static class PasswordHandler
    {
        public static void GeneratePasswordForUser()
        {
            var userData = ConsoleManager.ReadUserData();

            if (!userData.IsValid())
            {
                ConsoleManager.WriteBadData();
                return;
            }

            var encriptionManager = new EncriptionManager();

            string serialized = JsonConvert.SerializeObject(userData, Formatting.Indented);

            var encriptedData = encriptionManager.EncryptData(serialized);

            UserDataRepository.AddPassword(encriptedData);
            ConsoleManager.WritePassword(encriptedData);
        }

        public static void CheckPasswordForUser()
        {
            UserData decriptedUserInfo = null;
            var userPassword = ConsoleManager.ReadUserPassword();
            var encriptionManager = new EncriptionManager();

            try
            {
                var decriptedData = encriptionManager.DecryptData(userPassword);
                decriptedUserInfo = JsonConvert.DeserializeObject<UserData>(decriptedData);
            }
            catch {
                ConsoleManager.WriteBadData();
                return;
            }

            if (!decriptedUserInfo.IsExpired() && UserDataRepository.ExistsPassword(userPassword))
            {
                ConsoleManager.WritePassword(Status.Valid.ToString());
                UserDataRepository.RemovePassword(userPassword);
            }
            else
            {
                ConsoleManager.WritePassword(Status.NotValid.ToString());
            }
        }
    }
}
