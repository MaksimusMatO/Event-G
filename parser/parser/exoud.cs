using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;

namespace parser
{
    class Exoud
    {
        public string TextAnatation { get; set; }
        public string Url { get; set; }
        public string User { get; set; }
        public string Repo { get; set; }
        public string Star { get; set; }

        public void ParseStar()
        {
            string HttpApi = "https://api.github.com/repos/";
            string UrlStar = HttpApi + User + "/" + Repo;
            string Text;
            using (HttpClient wc = new HttpClient())
            {
                
            }
            string[] Line = Text.Split('\n');
            foreach (var v in Line)
            {
                if (v.StartsWith("\"stargazers_count\": "))
                {
                    string temp = v.Remove(0, 20);
                    Star = temp;
                }
            }

            //stargazers_count
        }

    }
}
