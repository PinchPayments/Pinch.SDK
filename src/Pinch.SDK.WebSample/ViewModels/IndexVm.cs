using System.Collections.Generic;
using System.Security.Claims;
using Pinch.SDK.Auth;

namespace Pinch.SDK.WebSample.ViewModels
{
    public class IndexVm
    {
        public string ConnectUrl { get; set; }
        public GetAccessTokenFromCodeResponse AccessToken { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
