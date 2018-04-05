using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;

namespace SimpleAuth.Api.Client.Resources.Interface
{
    public interface IAuthResource
    {
        BaseResponse<GetAccessTokenResponse> Login(LoginRequest request);

        BaseResponse<SearchResponse<GetAccessTokenResponse>> ListSessions(SearchSessionsRequest request, string token);

        BaseResponse<GetAccessTokenResponse> GetSession(string token);

        BaseResponse<object> Logout(string token);

        BaseResponse<object> LogoutAllExcept(string token);
    }
}
