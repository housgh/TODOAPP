namespace TODOAPP.Domain.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}