#if ANDROID
using Javax.Security.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endif

using NewsApplication.Models;
using Newtonsoft.Json;


namespace NewsApplication.Services
{
    public class ApiService
    {
        private string apiKey = "ffe6f376acb134542d9694b4a372cce8";
        public async Task<Root> GetNews(string categoryName = "general")
        {
            var httpClient = new HttpClient();
            var response = await  httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey={apiKey}&lang=en");
            return JsonConvert.DeserializeObject<Root>(response);       
        }
    }
}
