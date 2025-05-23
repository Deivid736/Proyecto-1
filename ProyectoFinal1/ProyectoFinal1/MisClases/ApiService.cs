using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InvestigadorAI
{
    public class ApiService  
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey  = "";
        private readonly string _endpoint = "https://api.openai.com/v1/chat/completions";

        public ApiService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<string> ConsultarTemaAsync(string tema)
        {
            var request = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Eres un asistente de investigación." },
                    new { role = "user", content = $"Investiga sobre: {tema}" }
                }
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);
            var responseString = await response.Content.ReadAsStringAsync();

            dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
            return jsonResponse.choices[0].message.content;
        }
    }
}