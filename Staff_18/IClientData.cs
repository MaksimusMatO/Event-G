using System.Collections.Generic;
using System.Net.Http;


namespace Karkov
{
    public interface IClientData
    {
        public SortedDictionary<string, decimal> MarketPlace { get; set; }
        public HttpClient Client { get; set; }
        public string Token { get; set; }
        public string SecretToken { get; set; }
    }
}
