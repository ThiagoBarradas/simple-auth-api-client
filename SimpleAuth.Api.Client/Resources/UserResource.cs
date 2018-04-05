using RestSharp;
using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;
using SimpleAuth.Api.Client.Resources.Interface;

namespace SimpleAuth.Api.Client.Resources
{
    public class UserResource : BaseResource, IUserResource
    {
        public UserResource(string baseUrl, int timeoutInSeconds = 30) :
            base(baseUrl, timeoutInSeconds)
        { }

        public BaseResponse<object> ConfirmUserEmail(ConfirmUserEmailRequest request)
        {
            BaseResponse<object> response = new BaseResponse<object>();

            IRestRequest restRequest = new RestRequest("users/email-activate/{emailConfirmationToken}", Method.PATCH);
            restRequest.AddUrlSegment("emailConfirmationToken", request.EmailConfirmationToken);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<object>(restResponse);
        }

        public BaseResponse<GetUserResponse> CreateUser(CreateUserRequest request)
        {
            BaseResponse<GetUserResponse> response = new BaseResponse<GetUserResponse>();

            IRestRequest restRequest = new RestRequest("users", Method.POST);
            restRequest.AddJsonBody(request);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetUserResponse>(restResponse);
        }

        public BaseResponse<GetUserResponse> GetUser(GetUserRequest request)
        {
            BaseResponse<GetUserResponse> response = new BaseResponse<GetUserResponse>();

            IRestRequest restRequest = new RestRequest("users/{userKey}", Method.GET);
            restRequest.AddUrlSegment("userKey", request.UserKey.ToString());
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetUserResponse>(restResponse);
        }

        public BaseResponse<object> IsEmailAvailable(IsEmailAvailableRequest request)
        {
            BaseResponse<object> response = new BaseResponse<object>();

            IRestRequest restRequest = new RestRequest("users/email/{email}/exists", Method.GET);
            restRequest.AddUrlSegment("email", request.Email);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<object>(restResponse);
        }

        public BaseResponse<SearchResponse<GetUserResponse>> ListUsers(SearchUsersRequest request)
        {
            BaseResponse<SearchResponse<GetUserResponse>> response = new BaseResponse<SearchResponse<GetUserResponse>>();

            IRestRequest restRequest = new RestRequest("users", Method.GET);
            restRequest.RequestFormat = DataFormat.Json;

            restRequest.AddQueryParameter("pageNumber", request.PageNumber.ToString());
            restRequest.AddQueryParameter("pageSize", request.PageSize.ToString());
            restRequest.AddQueryParameter("sortMode", request.SortMode.ToString());

            if (string.IsNullOrWhiteSpace(request.SortField) == false)
            {
                restRequest.AddQueryParameter("sortField", request.SortField.ToString());
            }

            if (string.IsNullOrWhiteSpace(request.Role) == false)
            {
                restRequest.AddQueryParameter("role", request.Role);
            }

            if (string.IsNullOrWhiteSpace(request.PermissionKey) == false)
            {
                restRequest.AddQueryParameter("permissionKey", request.PermissionKey);
            }

            if (request.IsActive != null)
            {
                restRequest.AddQueryParameter("isActive", request.IsActive.ToString());
            }

            if (string.IsNullOrWhiteSpace(request.Keywords) == false)
            {
                restRequest.AddQueryParameter("keywords", request.Keywords);
            }
            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<SearchResponse<GetUserResponse>>(restResponse);
        }

        public BaseResponse<GetUserResponse> UpdateUser(UpdateUserRequest request)
        {
            BaseResponse<GetUserResponse> response = new BaseResponse<GetUserResponse>();

            IRestRequest restRequest = new RestRequest("users/{userKey}", Method.PUT);
            restRequest.AddJsonBody(request);
            restRequest.AddUrlSegment("userKey", request.UserKey.ToString());
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetUserResponse>(restResponse);
        }
    }
}
