using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Ozon.MerchandiseService.HttpModels;

namespace Ozon.MerchandiseService.HttpClients
{
    public class MerchandiseServiceHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchItemResponse> GetMerch()
        {
            using var response = await _httpClient.GetAsync("/api/Merch/GetMerch");
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MerchItemResponse>(body);
        }
        
        public async Task<MerchItemResponse> GetInfoAboutMerch()
        {
            using var response = await _httpClient.GetAsync("/api/Merch/GetInfoAboutMerch");
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MerchItemResponse>(body);
        }
    }
}