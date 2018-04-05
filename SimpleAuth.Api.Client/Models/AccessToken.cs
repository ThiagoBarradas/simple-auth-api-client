using IpInfo.Api.Client.Models;
using System;
using UAUtil.Models;

namespace SimpleAuth.Api.Client.Models
{
    public class AccessToken
    {
        public string Token { get; set; }

        public Guid UserKey { get; set; }

        public DateTime CreateDate { get; set; }

        public string Ip { get; set; }

        public GetIpInfoResponse IpInfo { get; set; }

        public UserAgentDetails DeviceInfo { get; set; } 
    }
}
