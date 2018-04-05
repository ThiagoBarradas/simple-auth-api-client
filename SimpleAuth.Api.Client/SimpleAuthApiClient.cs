using SimpleAuth.Api.Client.Resources;
using SimpleAuth.Api.Client.Resources.Interface;

namespace SimpleAuth.Api.Client
{
    public class SimpleAuthApiClient : ISimpleAuthApiClient
    {
        /// <summary>
        /// Initializes client.
        /// </summary>
        /// <param name="baseUrl">api host</param>
        /// <param name="timeoutInSeconds">timeout in seconds</param>
        public SimpleAuthApiClient(string baseUrl, int timeoutInSeconds = 30)
        {
            this.User = new UserResource(baseUrl, timeoutInSeconds);
            this.Auth = new AuthResource(baseUrl, timeoutInSeconds);
            this.PasswordReset = new PasswordResetResource(baseUrl, timeoutInSeconds);
        }

        public IUserResource User { get; private set; }

        public IAuthResource Auth { get; private set; }

        public IPasswordResetResource PasswordReset { get; private set; }
    }
}
