using System.Text.Json;
using System.Text;


namespace DischargeSummaryDemo1.Services
{




    public class AIService
    {
        private readonly HttpClient _httpClient;

        public AIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string?> Prompt(string inputPrompt, string systemCommand)
        {
            var requestBody = new
            {
                model = "phi3:medium-128k",
                prompt = inputPrompt,
                system = systemCommand,
                stream = false
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                // Parse the JSON response to extract the "response" property
                var responseObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(responseContent);
                if (responseObject != null && responseObject.TryGetValue("response", out var responseElement))
                {
                    return responseElement.GetString();
                }
                else
                {
                    // Handle case where "response" is missing in the response
                    return null;
                }
            }
            else
            {
                // Handle error
                return null;
            }
        }
    }


}
