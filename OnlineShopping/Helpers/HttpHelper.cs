using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineShopping.Helpers
{
    public static class HttpHelper
    {
        /// <summary>
        /// Makes a GET call to an external API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            var httpClient = new HttpClient();
            // NOTE: In a prod ready code, this will need to handle any unexpected scenarios
            // e.g.: If the resource is not available. Or the resource returns an unexpected response. 
            var response = await httpClient.GetAsync(new Uri(url)).Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }
    }
}
