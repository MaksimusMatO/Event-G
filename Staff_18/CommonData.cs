using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkov
{
    public class CommonData : IMarketplacesData
    {
        public Dictionary<string, decimal> FirstMarketplace { get; set; }
        public Dictionary<string, decimal> SecondMarketplace { get; set; }
        public List<(string, string, string)> OutMarketPlace { get; set; }

        public CommonData(BaseRequestClient first, BaseRequestClient second)
        {
            FirstMarketplace = new Dictionary<string, decimal>();
            SecondMarketplace = new Dictionary<string, decimal>();
            OutMarketPlace = new List<(string, string, string)>();

            foreach (var item1 in first.MarketPlace)
            {
                foreach (var item2 in second.MarketPlace)
                {
                    if (item1.Key == item2.Key)
                    {
                        FirstMarketplace.Add(item1.Key, item1.Value);
                        SecondMarketplace.Add(item2.Key, item2.Value);
                    }
                }
            }
        }
        public void PrintClientData()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pair/BTC\tFirst market\t\tSecond market\t\t");
            Console.ResetColor();
            char symbol;
            decimal difference;

            foreach (var item1 in FirstMarketplace)
            {
                foreach(var item2 in SecondMarketplace)//  | (a — b) / [ (a + b) / 2 ] | * 100 %
                {
                    if (item1.Key == item2.Key)
                    {
                        symbol = ComparisonPlatform(item1.Value, item2.Value);
                        difference = ComparisonPlatformDecimal(item1.Value, item2.Value, symbol);
                        if (difference >= 10)
                        {
                            Console.WriteLine($"{item1.Key.Replace("BTC", "")}\t\t{item1.Value}\t{symbol}\t{item2.Value}\t/{difference}");
                            GetLess(item1, item2, symbol);
                        }
                        
                        break;// мб оптимизация (тип если нашел совпадение ключей - дальше нет смысла идти)
                    }                   
                }                                        
            }
        }

        private void GetLess(KeyValuePair<string, decimal> item1, KeyValuePair<string, decimal> item2, char symbol)
        {
            if (symbol == '<')
            {
                OutMarketPlace.Add((item1.Key, "binance", "gate"));
            }
            else
            {
                OutMarketPlace.Add((item2.Key, "gate", "binance"));
            }
            
        }

        private decimal ComparisonPlatformDecimal(decimal a, decimal b, char symbol)
        {
            decimal difference = 0;
            if (symbol == '>')
            {
                difference = ((a - b) / a) * 100;
            }
            if (symbol == '<')
            {
                difference = ((b - a) / b) * 100;
            }
            return difference;
        }

        private char ComparisonPlatform(decimal value1, decimal value2)
        {
            if (value1 > value2)
            {
                return '>';
            }
            if (value1 < value2)
            {
                return '<';
            }
            if (value1 == value2)
            {
                return '=';
            }
            return '?';

        }

        public List<(string, string, string)> GetTails()
        {
            return OutMarketPlace;
        }
    }
}
