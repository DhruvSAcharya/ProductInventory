namespace CommonUtilies
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync();
    }


    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly HttpClient _httpClient;

        public AuthorizationMessageHandler(ITokenProvider tokenProvider, HttpClient httpClient)
        {
            _tokenProvider = tokenProvider;
            _httpClient = httpClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenProvider.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            if (!_httpClient.BaseAddress.IsAbsoluteUri)
            {
                request.RequestUri = new Uri(_httpClient.BaseAddress, request.RequestUri);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
