using DitConMeMayWASM.Interface;
using DitConMeMayWASM.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS_FPL.Controller
{
    public class ApiServices : IApiData
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public ApiServices(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public ApiServices()
        {

        }
        [HttpGet]
        public async Task<List<Users>> GetUsers()
        {
            var response = await _client.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<List<Users>>(content, _options);
            return products;
        }

    }
}
