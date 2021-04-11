using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace parser
{
    class WebResp
    {
        static WebClient WClient = new WebClient();
        static Regex regex = null;
        static string WResponse = null;
        static string[] LineStr = null;
        public void StartWebResp(string addres)
        {
            WResponse = WClient.DownloadString(addres);

            LineStr = FilterRespons();

            HttpResp hr = new HttpResp();
            hr.RunResp(LineStr);
            

        }
        static string[] FilterRespons()
        {
            string[] TempLine = WResponse.Split('\n');
            string[] Str = new string[WResponse.Length];
            int IndexStr = 0;

            foreach (var v in TempLine)
            {
                regex = new Regex(@"\* [[].*[]][(]https://github\.com/.*[)].*");
                bool stat = regex.IsMatch(v);
                if ( stat )
                {
                    Str[IndexStr] = v;
                    //Thread.Sleep(600);

                    Console.WriteLine(v.TrimStart(' '));

                    IndexStr++;
                }
                
            }
            

            return Str;
        }

    }
}
