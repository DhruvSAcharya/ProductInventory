﻿namespace CommonUtilies
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync();
    }


    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ITokenProvider _tokenProvider;

        public AuthorizationMessageHandler(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenProvider.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
