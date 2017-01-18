namespace Academy.Models
{
    using System;

    public abstract class User : IUser
    {
        private const int UsernameMinLength = 3;
        private const int UsernameMaxLength = 16;

        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < UsernameMinLength || value.Length > UsernameMaxLength)
                {
                    throw new ArgumentException(string.Format("User's username should be between {0} and {1} symbols long!", UsernameMinLength, UsernameMaxLength));
                }

                this.username = value;
            }
        }
    }
}
