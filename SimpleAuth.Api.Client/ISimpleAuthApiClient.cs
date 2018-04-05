using SimpleAuth.Api.Client.Resources.Interface;

namespace SimpleAuth.Api.Client
{
    public interface ISimpleAuthApiClient
    {
        IUserResource User { get; }

        IAuthResource Auth { get; }

        IPasswordResetResource PasswordReset { get; }
    }
}
