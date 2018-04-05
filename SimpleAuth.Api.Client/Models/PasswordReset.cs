using SimpleAuth.Api.Client.Models.Enums;
using System;

namespace SimpleAuth.Api.Client.Models
{
    public class PasswordReset
    {
        public Guid UserKey { get; set; }

        public string Token { get; set; }

        public PasswordResetStatusEnum Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public long ExpiresInMs { get; set; }
    }
}
