using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{ 
    using Common.Providers;
    using Contracts;

    public class User : IUser
    {
        private readonly Validator validator = new Validator();

        private string username;
        private string email;

        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                this.validator.Validate(value);
                this.username = value;
            }
        }

        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email
        {
            get
            {
                return this.email;
            }

            private set
            {
                this.validator.Validate(value);                
                this.email = value;
            }
        }
        
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Username: " + this.Username);
            builder.AppendLine("    Email: " + this.Email);

            return builder.ToString();
        }
    }
}