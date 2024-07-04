namespace ServitiaTest_Backend_Api.Controllers.Authentication
{
    public class AuthenticateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthenticateRequest()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
