namespace SimpleAuth.Api.Client.Models.Response
{
    public class GetAccessTokenResponse : AccessToken
    {
        public GetUserResponse User { get; set; }
    }
}
