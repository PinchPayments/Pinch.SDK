using System.Collections.Generic;
using Pinch.SDK.Auth;

namespace Pinch.SDK.WebSample.ViewModels
{
    public class IndexVm
    {
        public GetAccessTokenResponse AccessToken { get; set; }
        public List<GetClaimsResponseItem> Claims { get; set; }
    }
}
