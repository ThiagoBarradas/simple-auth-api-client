using SimpleAuth.Api.Client.Models;
using SimpleAuth.Api.Client.Models.Request;
using SimpleAuth.Api.Client.Models.Response;

namespace SimpleAuth.Api.Client.Resources.Interface
{
    public interface IPasswordResetResource
    {
        BaseResponse<GetPasswordResetResponse> CreatePasswordReset(CreatePasswordResetRequest request);

        BaseResponse<GetPasswordResetResponse> GetPasswordReset(GetPasswordResetRequest request);

        BaseResponse<object> UsePasswordReset(UsePasswordResetRequest request);
    }
}
