using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sadilov
{
    internal class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        // Используем бесплатный и стабильный эндпоинт без обязательной сложной регистрации
        public async Task<ExchangeRateResponse> GetLatestRatesAsync(string baseCurrency)
        {
            try
            {
                // Запрос отправляется на эндпоинт получения актуальных курсов относительно выбранной валюты
                string url = $"https://open.er-api.com/v6/latest/{baseCurrency}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении данных API: {ex.Message}");
            }
        }
    }
}
