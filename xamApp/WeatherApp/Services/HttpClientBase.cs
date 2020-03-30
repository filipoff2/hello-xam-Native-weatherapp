using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utils.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.Utils;

namespace WeatherApp.Services
{
    public class HttpClientBase : IHttpClient
    {
        private readonly JsonConverter _dateTimeConverter = new TimestampJsonConverter();

        public async Task<T> DoGetRequest<T>(string url)
        {
            if (url == null) {
                Logger.LogWarning("url is null");
                return default(T);
            }

            using (HttpClient _client =  new HttpClient()) {
                var json = await _client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<T>(json, _dateTimeConverter);
                return result;
            }

        }
    }
}
