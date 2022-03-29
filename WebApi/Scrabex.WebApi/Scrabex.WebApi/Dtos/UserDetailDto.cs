namespace Scrabex.WebApi.Dtos
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool ForgotPassword { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
