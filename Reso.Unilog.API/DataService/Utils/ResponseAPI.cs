using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniLogLibCore.Library;

namespace DataService.Utils
{
    
    public  interface IResponseAPI
    {
        StringContent GetContent<T>(T data);
        Task<T> ReadAsJsonAsync<T>(HttpContent content);
    }
    public  class ResponseAPI : IResponseAPI
    {
        private readonly UniLogConfigModel _config;
        private HttpClient client = new HttpClient();

        /// <summary>
        /// Constructor
        /// </summary>
        public  ResponseAPI()
        {
            _config = UniLogConfig.GetConfigModel();
        }

        public  HttpClient Initial()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_config.UniLogUrl)
            };
            return client;
        }

        /// <summary>
        /// Convert Content To String Content
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public  StringContent GetContent<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataConvert, UnicodeEncoding.UTF8, "application/json");
            return content;
        }

        /// <summary>
        /// Read Json as Convert To Data
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="content">HttpContent</param>
        /// <returns></returns>
        public  async Task<T> ReadAsJsonAsync<T>(HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }

    }
}
