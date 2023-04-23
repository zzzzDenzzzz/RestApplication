namespace RestApplication.Models
{
    public class Response
    {
        public User? User { get; set; }
        public string? Token { get; set; }
        public int Token_expire { get; set; }
        public string? Refresh_token { get; set; }
        public int Refresh_token_expire { get; set; }
        public bool Success { get; set; }
    }
}
