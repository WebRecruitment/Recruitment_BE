

namespace WebRecruitment.Application.Model.Request.AuthenRequest
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string UserEmail { get; set; }
    }
}
