using RestSharp;
using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;
using SimpleAuth.Api.Client.Resources.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuth.Api.Client.Resources
{
    public class AuthResource : BaseResource, IAuthResource
    {
        public AuthResource(string baseUrl, int timeoutInSeconds = 30) :
            base(baseUrl, timeoutInSeconds)
        { }

        public BaseResponse<GetAccessTokenResponse> GetSession(string token)
        {
            BaseResponse<GetAccessTokenResponse> response = new BaseResponse<GetAccessTokenResponse>();

            IRestRequest restRequest = new RestRequest("sessions/current", Method.GET);
            restRequest.AddHeader("Authorization", token);
            restRequest.RequestFormat = DataFormat.Json;
            
            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<GetAccessTokenResponse>(restResponse);
        }

        public BaseResponse<SearchResponse<GetAccessTokenResponse>> ListSessions(SearchSessionsRequest request, string token)
        {
            BaseResponse<SearchResponse<GetAccessTokenResponse>> response = new BaseResponse<SearchResponse<GetAccessTokenResponse>>();

            IRestRequest restRequest = new RestRequest("sessions", Method.GET);
            restRequest.AddHeader("Authorization", token);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddQueryParameter("pageNumber", request.PageNumber.ToString());
            restRequest.AddQueryParameter("pageSize", request.PageSize.ToString());
            restRequest.AddQueryParameter("sortMode", request.SortMode.ToString());

            if (string.IsNullOrWhiteSpace(request.SortField) == false)
            {
                restRequest.AddQueryParameter("sortField", request.SortField.ToString());
            }

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<SearchResponse<GetAccessTokenResponse>>(restResponse);
        }

        public BaseResponse<GetAccessTokenResponse> Login(LoginRequest request)
        {
            BaseResponse<GetAccessTokenResponse> response = new BaseResponse<GetAccessTokenResponse>();

            IRestRequest restRequest = new RestRequest("login", Method.POST);
            restRequest.AddHeader("X-Forwarded-For", request.Ip);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(request);

            this.RestClient.UserAgent = request.UserAgent;
            IRestResponse restResponse = this.RestClient.Execute(restRequest);
            this.ResetUserAgent();

            return this.HandleResponse<GetAccessTokenResponse>(restResponse);
        }

        public BaseResponse<object> Logout(string token)
        {
            BaseResponse<object> response = new BaseResponse<object>();

            IRestRequest restRequest = new RestRequest("logout", Method.DELETE);
            restRequest.AddHeader("Authorization", token);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<object>(restResponse);
        }

        public BaseResponse<object> LogoutAllExcept(string token)
        {
            BaseResponse<object> response = new BaseResponse<object>();

            IRestRequest restRequest = new RestRequest("logout/all", Method.DELETE);
            restRequest.AddHeader("Authorization", token);
            restRequest.RequestFormat = DataFormat.Json;
            
            IRestResponse restResponse = this.RestClient.Execute(restRequest);

            return this.HandleResponse<object>(restResponse);
        }
    }
}
