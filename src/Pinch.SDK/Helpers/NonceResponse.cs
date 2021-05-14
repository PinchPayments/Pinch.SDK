namespace Pinch.SDK.Helpers
{
    public class NonceResponse<T>
    {
        public bool IsNonceReplay { get; set; }
        public string Nonce { get; set; }
        public T Data { get; set; }
    }
}