namespace Politick.Api.Models
{
    public class CreateUser : UserCredentials
    {
        public CreateUser(string email, string password) : base(email, password) { }
    }
}