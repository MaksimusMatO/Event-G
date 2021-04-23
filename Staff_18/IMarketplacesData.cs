using System.Collections.Generic;


namespace Karkov
{
    interface IMarketplacesData
    {
        public Dictionary<string, decimal> FirstMarketplace { get; set; }// 1 площадка
        public Dictionary<string, decimal> SecondMarketplace { get; set; }// 2 площадка
        public void PrintClientData();
    }
}
