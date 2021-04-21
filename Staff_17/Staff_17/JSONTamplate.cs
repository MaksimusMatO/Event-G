using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Staff_17
{
    class JSONTamplate
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }
        public JSON_2 Run()
        {
            JSON_2 Out = JsonConvert.DeserializeObject<JSON_2>(Result);
            return Out;
        }
    }
}
