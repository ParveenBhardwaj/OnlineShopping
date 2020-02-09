using Newtonsoft.Json;
using OnlineShopping.Domain.Models;
using System;
using System.Net.Http;
using System.Text;
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
            var response = await httpClient.GetAsync(new Uri(url)).Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        /// <summary>
        /// Makes a POST call to an external API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="tItem">Trolley Item: It specifies the price, quantity and specials</param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, TrolleyItem tItem)
        {
            StringContent cont = new StringContent(JsonConvert.SerializeObject(tItem), Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(new Uri(url), cont);
            var responseContent = response.Content;
            var rs = await responseContent.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(rs);
            return result;
        }
    }
}
