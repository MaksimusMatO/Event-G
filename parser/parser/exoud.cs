
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
        public string star { get; set; }

        public void ParseStar()
        {
            string HttpApi = "http://api.github.com/repos/";
            string UrlStar = HttpApi + User + "/" + Repo;




        }
        

    }
}
