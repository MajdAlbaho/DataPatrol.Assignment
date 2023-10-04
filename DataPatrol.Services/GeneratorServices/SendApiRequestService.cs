using DataPatrol.Services.IGeneratorServices;

namespace DataPatrol.Services.GeneratorServices
{
    public class SendApiRequestService : ISendApiRequestService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<string> SendApiRequest(string endPoint) {
            var response = await HttpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }

            return null;
        }
    }
}
