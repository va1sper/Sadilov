using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace Sadilov
{
    internal class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<ExchangeRateResponse> GetLatestRatesAsync(string baseCurrency)
        {
            try
            {
                string url = $"https://open.er-api.com/v6/latest/{baseCurrency}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"ошибка при получении данных API: {ex.Message}");
            }
        }
        public async Task<ExchangeRateResponse> GetHistoricalRatesAsync(string baseCurrency, int year, int month, int day)
        {
            try
            {
                string dateStr = $"{day:D2}/{month:D2}/{year}";
                string url = $"https://www.cbr.ru/scripts/XML_daily.asp?date_req={dateStr}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                XDocument xmlDoc = XDocument.Load(stream);

                var ratesInRub = new Dictionary<string, double>();
                ratesInRub["RUB"] = 1.0;

                foreach (XElement valuteNode in xmlDoc.Descendants("Valute"))
                {
                    string code = valuteNode.Element("CharCode")?.Value;
                    string nominalStr = valuteNode.Element("Nominal")?.Value;
                    string valueStr = valuteNode.Element("Value")?.Value;

                    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(valueStr))
                    {
                        string standardizedValue = valueStr.Replace(",", ".");
                        string standardizedNominal = nominalStr.Replace(",", ".");

                        double value = double.Parse(standardizedValue, CultureInfo.InvariantCulture);
                        double nominal = double.Parse(standardizedNominal, CultureInfo.InvariantCulture);

                        ratesInRub[code] = value / nominal;
                    }
                }

                var finalRates = new Dictionary<string, double>();

                if (ratesInRub.ContainsKey(baseCurrency))
                {
                    double baseInRub = ratesInRub[baseCurrency];
                    string[] my6Currencies = { "USD", "EUR", "RUB", "GBP", "JPY", "CAD" };

                    foreach (string cur in my6Currencies)
                    {
                        if (ratesInRub.ContainsKey(cur))
                        {
                            finalRates[cur] = baseInRub / ratesInRub[cur];
                        }
                    }
                }

                var exchangeResponse = new ExchangeRateResponse();
                exchangeResponse.Rates = finalRates;
                return exchangeResponse;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"крит ошибка цб: {ex.Message}");
                return null;
            }
        }
    }
}
