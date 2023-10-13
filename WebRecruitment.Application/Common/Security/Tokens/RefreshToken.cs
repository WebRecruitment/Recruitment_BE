namespace WebRecruitment.Application.Common.Security.Tokens
{
    public class RefreshToken 
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
