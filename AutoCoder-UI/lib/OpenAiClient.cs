using AutoCoder_UI.lib;
using System.IO;
using System.Net.Http;
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
        

        internal async Task<Response> CallChatCompletionAsync(ChatCompletionParams parameters, string API_URL)
        {

            var requestJson = JsonSerializer.Serialize(parameters);

            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(API_URL, requestContent);

            if (await response.Content.ReadAsStringAsync() is string responseJson)
            {
                return JsonSerializer.Deserialize<Response>(responseJson);
            }

            return null;
        }

        internal async Task<Response> CallChatStreamingCompletionAsync(ChatCompletionParams parameters, string API_URL)
        {

            var requestJson = JsonSerializer.Serialize(parameters);

            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(API_URL, requestContent);
            using (var streamReader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = await streamReader.ReadLineAsync();
                    Console.WriteLine(line); // or process the line as needed
                }
            }

            return null;
        }


    }
}
