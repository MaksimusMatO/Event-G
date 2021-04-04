using System;
using System.IO;
using System.Net;

namespace parser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string end;
            string url = "https://raw.githubusercontent.com/vinta/awesome-python/master/README.md";
            var request = (HttpWebRequest)WebRequest.Create(url);// создание запроса по  url запрос. используем upncast

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();// создание ответа по запросу. используем приведение типов
            Stream stream = response.GetResponseStream();//переводим в текст ответ
            using (StreamReader streamReader = new StreamReader(stream) )//создаём SR для чтения в строки
            {
                end = streamReader.ReadToEnd();
            }


            string[] LinesString = end.Split('\n');
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Персональный\\Desktop\\проги\\stream.txt"))//создаём SW для записи в фаил
            {
                
                foreach (string i in LinesString)
                {
                    if (i.StartsWith('*'))//если *
                    {
                        sw.WriteLine(i, true);
                    }
                    
                }
            }

            

            //Console.WriteLine(end);
        }
    }
}
