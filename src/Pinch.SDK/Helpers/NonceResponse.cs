namespace Pinch.SDK.Helpers
{
    public class NonceResponse
    {
        public bool IsNonceReplay { get; set; }
        public string Nonce { get; set; }
    }

    public class NonceResponse<T> : NonceResponse
    {
        public T Data { get; set; }
    }
}