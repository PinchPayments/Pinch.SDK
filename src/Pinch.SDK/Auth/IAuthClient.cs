using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pinch.SDK.Auth
{
    public interface IAuthClient
    {
        string GetConnectUrl(string applicationId, string redirectUri);
        Task<GetAccessTokenFromCodeResponse> GetAccessTokenFromCode(string code, string clientId, string redirectUri);
        Task<GetAccessTokenFromSecretKeyResponse> GetAccessTokenFromSecretKey(string secretKey, string clientId);
        Task<GetAccessTokenFromRefreshTokenResponse> GetAccessTokenFromRefreshToken(string refreshToken, string secretKey, string clientId);
        Task<List<Claim>> GetClaims(string accessToken);
    }
}