using System.Collections.Generic;
using Xunit;

namespace Pinch.SDK.Tests.ApiClientTests
{
    public class PinchApiTests
    {
        private readonly PinchApi _pinchApi;

        public PinchApiTests()
        {
            _pinchApi = new PinchApi("merchantId", "secretKey", false);
        }

        [Fact]
        public void GivenParametersAsCodeTokenThenShouldEncodeCorrectly()
        {
        }
    }
}
