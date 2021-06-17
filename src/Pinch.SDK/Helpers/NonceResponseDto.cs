namespace Pinch.SDK.Helpers
{
    public class NonceResponseDto
    {
        public bool IsNonceReplay { get; set; }
        public string Nonce { get; set; }
    }

    public class NonceResponseDto<T> : NonceResponseDto
    {
        public T Data { get; set; }
    }
}