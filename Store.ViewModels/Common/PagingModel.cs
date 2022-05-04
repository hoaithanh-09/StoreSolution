using Newtonsoft.Json;
using System.Collections.Generic;

namespace Store.ViewModels.Common
{
    public class PagingModel
    {
        [JsonProperty("totalCounts")]
        public dynamic TotalCounts { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }

    public class PagingModel<T>
    {
        [JsonProperty("totalCounts")]
        public dynamic TotalCounts { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
