using Newtonsoft.Json;
using RestSharp;
using SimpleAuth.Api.Client.Models;
using System.Net;

namespace SimpleAuth.Api.Client.Resources
{
    public class BaseResource
    {
        public string BaseUrl { get; set; }

        public int TimeoutInSeconds { get; set; }

        public IRestClient RestClient { get; set; }

        /// <summary>
        /// Initializes client.
        /// </summary>
        /// <param name="baseUrl">api host</param>
        /// <param name="timeoutInSeconds">timeout in seconds</param>
        public BaseResource(string baseUrl, int timeoutInSeconds = 30)
        {
            this.BaseUrl = baseUrl;
            this.TimeoutInSeconds = timeoutInSeconds;
            this.RestClient = new RestClient(this.BaseUrl);
            RestClient.Timeout = this.TimeoutInSeconds * 1000;
            this.ResetUserAgent();
        }

        protected void ResetUserAgent()
        {
            this.RestClient.UserAgent = "SimpleAuth.Api.Clients";
        }

        protected BaseResponse<T> HandleResponse<T>(IRestResponse restResponse)
        {
            BaseResponse<T> response = new BaseResponse<T>();

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;

            if (restResponse.StatusCode == HttpStatusCode.OK ||
                restResponse.StatusCode == HttpStatusCode.Created ||
                restResponse.StatusCode == HttpStatusCode.NoContent ||
                restResponse.StatusCode == HttpStatusCode.Accepted)
            {
                response.IsSuccess = true;

                if (string.IsNullOrWhiteSpace(restResponse.Content) == false)
                {
                    response.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
                }
            }
            else 
            {
                response.IsSuccess = false;
                if (string.IsNullOrWhiteSpace(restResponse.Content) == false)
                {
                    response.Errors = JsonConvert.DeserializeObject<ErrorsResponse>(restResponse.Content);
                }
            }

            return response;
        }
    }
}
