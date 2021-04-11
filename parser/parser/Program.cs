using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parser
{

    class Program
    {
        static void Main(string[] args)
        {
            string Url = "https://raw.githubusercontent.com/vinta/awesome-python/master/README.md";

            WebResp wr = new WebResp();
            wr.StartWebResp(Url);


            Thread.Sleep(5000);
        }

    }
}