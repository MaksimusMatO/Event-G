using System;
using System.IO;
using System.Net;
using System.Text;

namespace parser
{
    
    class Program
    {
        static string PathPre = "C:\\Users\\Персональный\\Desktop\\проги\\stream\\reqwest";
        static string Type = ".txt";
        static void Main(string[] args)
        {
            string Url = "https://raw.githubusercontent.com/vinta/awesome-python/master/README.md";
            string Text;

            Text = ResponsOnReqwest(Url);
            Text = WorkText_I_(Text);
            Exoud[] exo = CreatClass(Text);
            PrintClasInfo(exo);

        }

        static Exoud[] CreatClass(string text)
        {
            string[] TextLine = text.Split('\n');
            string[] name;
            string[] repo;
            string[] url = CreatClassName(TextLine, out name, out repo);
            Exoud[] exoud = new Exoud[TextLine.Length];
            int EIndex = 0;

            foreach (var v in TextLine)
            {
                exoud[EIndex] = new Exoud();
                exoud[EIndex].TextAnatation = v;
                exoud[EIndex].User = name[EIndex];
                exoud[EIndex].Repo = repo[EIndex];
                exoud[EIndex].Url = url[EIndex];
                exoud[EIndex].ParseStar();

                EIndex++;
            }

            return exoud;
        }
        static string[] CreatClassName(string[] Line, out string[] name, out string[] repo)
        {
            name = new string[Line.Length];
            repo = new string[Line.Length];
            for (int i = 0; i < Line.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                int ISart = Line[i].IndexOf("(");
                int IEnd = Line[i].IndexOf(")");

                for (int j = ISart + 1; j < IEnd; j++ )
                {
                    sb.Append(Line[i][j]);
                }
                Line[i] = sb.ToString();
                string line = Line[i];

                if (line.StartsWith("https://github.com/"))
                {
                    line = line.Remove(0, 19);


                    sb = new StringBuilder();
                    ISart = line.IndexOf('/');
                    IEnd = line.Length;

                    for (int j = 0; j < ISart; j++)
                    {
                        sb.Append(line[j]);
                    }
                    name[i] = sb.ToString();
                    sb = new StringBuilder();

                    for (int j = ISart + 1; j < IEnd ; j++)
                    {
                        sb.Append(line[j]);
                    }
                    repo[i] = sb.ToString();
                }
                else
                {
                    continue;
                }
            }

            return Line;
        }
        static void PrintClasInfo(Exoud[] exo)
        {
            using (StreamWriter sw = new StreamWriter(PathPre + '3' + Type))
            {
                foreach (var v in exo)
                {

                    sw.WriteLine("{0}::{1}::{2}::{3}::{4}",
                        v.TextAnatation,
                        v.User,
                        v.Repo,
                        v.Url,
                        v.Star);
                }
            }
        }
        static string ResponsOnReqwest(string Url)
        {
            WebClient webClient = new WebClient();
            string reqwest = webClient.DownloadString(Url);

            return reqwest;
        }
        static string WorkText_I_(string text)
        {
            string str;
            string[] TextLine = text.Split('\n');

            using (StreamWriter sw = new StreamWriter(PathPre + "2" + Type))
            {
                foreach (var v in TextLine)
                {
                    v.TrimStart(' ');
                    if (v.StartsWith("* ["))
                    {
                        sw.WriteLine(v, true);
                    }
                }
            }
            using (StreamReader sr = new StreamReader(PathPre + "2" + Type))
            {
                str = sr.ReadToEnd();
            }

            return str;
        }
        static void WriteFiel_I_(string text)
        {
            using (StreamWriter sw = new StreamWriter(PathPre + "1" + Type))
            {
                sw.WriteLine(text);
            }
        }
    }
}
