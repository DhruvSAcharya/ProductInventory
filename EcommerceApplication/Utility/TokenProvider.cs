using CommonUtilies;
using System.Net.Http.Headers;

namespace EcommerceApplication.Utility
{
    public class TokenProvider : ITokenProvider
    {
        public async Task<string> GetTokenAsync()
        {
            string token = string.Empty;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5212/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/login");

                if (response.IsSuccessStatusCode)
                {
                    token = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    token =  string.Empty;
                }
            }
            return await Task.FromResult(token);
            
        }
    }
}
