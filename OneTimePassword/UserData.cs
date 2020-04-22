using System;

namespace OneTimePassword
{
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(int userId, DateTime useDate)
        {
            UserId = userId;
            UserDate = useDate;
            ValidUntil = DateTime.Now.AddMinutes(Configuration.PasswordDuration);
        }

        public int UserId { get; set; }

        public DateTime UserDate { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool IsValid()
        {
            return !(UserId.Equals(default(int)) || UserDate.Equals(default(DateTime)));
        }

        public bool IsExpired()
        {
            return ValidUntil < DateTime.Now;
        }
    }
}
