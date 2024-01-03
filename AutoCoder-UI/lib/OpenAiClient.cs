using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AutoCoder_UI.lib
{
    public class OpenAiClient
    {
        private readonly HttpClient _httpClient;

        public OpenAiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.Timeout = TimeSpan.FromSeconds(60000);
        }
    

        internal async Task<Response> CallChatCompletionAsync(ChatCompletionParams parameters)
        {
            string url = "https://iconofgaming.com:5000/v1/chat/completions/";

            var requestJson = JsonSerializer.Serialize(parameters);

            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, requestContent);

            if (await response.Content.ReadAsStringAsync() is string responseJson)
            {
                return JsonSerializer.Deserialize<Response>(responseJson);
            }

            return null;
        }


    }
}
