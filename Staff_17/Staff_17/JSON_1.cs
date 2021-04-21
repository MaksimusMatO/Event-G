
using System.Text.Json.Serialization;


namespace Staff_17
{
    class JSON_1
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("price")]
        public string Price { get; set; }

    }
}
