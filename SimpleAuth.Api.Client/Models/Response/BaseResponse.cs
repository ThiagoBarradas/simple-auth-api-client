using System.Net;

namespace SimpleAuth.Api.Client.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public ErrorsResponse Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }
    }
}
