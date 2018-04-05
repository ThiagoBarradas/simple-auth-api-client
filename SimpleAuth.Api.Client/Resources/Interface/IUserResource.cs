using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;

namespace SimpleAuth.Api.Client.Resources.Interface
{
    public interface IUserResource
    {
        BaseResponse<GetUserResponse> CreateUser(CreateUserRequest request);

        BaseResponse<GetUserResponse> UpdateUser(UpdateUserRequest request);

        BaseResponse<GetUserResponse> GetUser(GetUserRequest request);

        BaseResponse<SearchResponse<GetUserResponse>> ListUsers(SearchUsersRequest request);

        BaseResponse<object> IsEmailAvailable(IsEmailAvailableRequest request);

        BaseResponse<object> ConfirmUserEmail(ConfirmUserEmailRequest request);
    }
}
