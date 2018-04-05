using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuth.Api.Client.Models.Request
{
    public class UpdateUserRequest : CreateUserRequest
    {
        public Guid UserKey { get; set; }
    }
}