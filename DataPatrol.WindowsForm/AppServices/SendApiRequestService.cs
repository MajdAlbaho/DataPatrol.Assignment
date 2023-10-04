using System.Net.Http;
using System.Threading.Tasks;

namespace DataPatrol.WindowsForm.AppServices
{
    public class SendApiRequestService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<string> CallApi(string endPoint) {
            var response = await HttpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }

            return null;
        }
    }
}
