namespace dotNetServer.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}