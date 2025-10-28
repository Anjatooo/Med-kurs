namespace WebApplication3.Models.JWT
{
    public class Auth
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; }
    }
}
