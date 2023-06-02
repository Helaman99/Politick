namespace Politick.Api.Models
{
    public class CreatePlayer : PlayerCredentials
    {
        public CreatePlayer(string email, string password) : base(email, password) { }
    }
}