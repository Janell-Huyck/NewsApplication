using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApplication.Models
{
    public class Root
    {
        [JsonProperty("totalArticles")]
        public int TotalArticles { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }

    public class Source
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
