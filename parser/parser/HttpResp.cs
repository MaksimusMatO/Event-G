using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace parser
{
    class HttpResp
    {
        static string[] tempName = null;
        static HttpClient HClient = new HttpClient();
        

        public void RunResp(string[] LineList)
        {
            FilterLL(LineList);
            GetResp();
        }
        public void GetResp()
        {
            string address = CreateUrl(tempName[0]);


            GetProductAsinc(address);
        }
        static async Task GetProductAsinc(string address)
        {

            Console.WriteLine(await HClient.GetStringAsync(address));
        }
        static void FilterLL(string[] str)
        {
            tempName = new string[str.Length];
            int IndexTemp = 0;
            foreach (var v in str)
            {
                if (v != null)
                {
                    Match match = Regex.Match(v, @"\* (.*)https://github\.com/(.+?)\)(.*)");
                    tempName[IndexTemp] = match.Groups[2].Value;
                    tempName[IndexTemp] = tempName[IndexTemp].TrimEnd('/');

                    //Console.WriteLine(tempName[IndexTemp]);

                    IndexTemp++;
                }
            }
        }
        static string CreateUrl(string str)
        {
            string pref = "https://api.github.com/repos/";
            //string postf = "/commits";

            return pref + str;
        }

    }
}
