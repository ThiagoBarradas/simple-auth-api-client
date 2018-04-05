using RestSharp;
using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;
using SimpleAuth.Api.Client.Resources.Interface;

namespace SimpleAuth.Api.Client.Resources
{
    public class PasswordResetResource : BaseResource, IPasswordResetResource
    {
        public PasswordResetResource(string baseUrl, int timeoutInSeconds = 30) :
            base(baseUrl, timeoutInSeconds) { }

        public BaseResponse<GetPasswordResetResponse> CreatePasswordReset(CreatePasswordResetRequest request)
        {
            BaseResponse<GetPasswordResetResponse> response = new BaseResponse<GetPasswordResetResponse>();

            IRestRequest restRequest = new RestRequest("password-resets/{email}", Method.POST);
            restRequest.AddUrlSegment("email", request.Email);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetPasswordResetResponse>(restResponse);
        }

        public BaseResponse<GetPasswordResetResponse> GetPasswordReset(GetPasswordResetRequest request)
        {
            BaseResponse<GetPasswordResetResponse> response = new BaseResponse<GetPasswordResetResponse>();

            IRestRequest restRequest = new RestRequest("password-resets/{token}", Method.GET);
            restRequest.AddUrlSegment("token", request.Token);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetPasswordResetResponse>(restResponse);
        }

        public BaseResponse<object> UsePasswordReset(UsePasswordResetRequest request)
        {
            BaseResponse<object> response = new BaseResponse<object>();

            IRestRequest restRequest = new RestRequest("password-resets/{token}", Method.PUT);
            restRequest.AddUrlSegment("token", request.Token);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(request);

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<object>(restResponse);
        }
    }
}
