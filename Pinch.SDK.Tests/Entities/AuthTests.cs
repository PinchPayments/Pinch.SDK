using System.Net;
using Moq;
using Pinch.SDK.Auth;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq.Protected;
using Xunit;

namespace Pinch.SDK.Tests.Entities
{
    public class AuthTests
    {
        public AuthTests()
        {
        }

        [Fact] public void DoesSetCorrectAuthClientUrl()
        {
            var mockFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'name':thecodebuzz,'city':'USA'}"),
                });
            
            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            var auth = new AuthClient("secretKey", "http://auth.getpinch.com.au", "http://api.getpinch.com.au", null, () => mockFactory.Object.CreateClient());
            Assert.Equal("http://auth.getpinch.com.au/connect/authorize?client_id=app_id&redirect_uri=http://localhost:5555&response_type=code&scope=api1 offline_access openid", auth.GetConnectUrl("app_id", "http://localhost:5555"));

            var response = auth.GetAccessTokenFromCode("code", "clientId", "http://localhost:555");
            var test = response.Result;

        }
    }
}
