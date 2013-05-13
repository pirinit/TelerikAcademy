using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace _1.InternetGraphAlgo
{
    class Program
    {
        static Dictionary<string, int> pagesDictionary;
        static Dictionary<string, string> hrefDictionary;
        static List<string> pagesList;
        static Queue<Uri> pagesToProcess;


        static void Main(string[] args)
        {
            pagesDictionary = new Dictionary<string, int>();
            hrefDictionary = new Dictionary<string, string>();
            pagesList = new List<string>();
            pagesToProcess = new Queue<Uri>();
            
            
            Uri startUri = new Uri("http://academy.telerik.com/academy");
            //startUri = new Uri("http://www.youtube.com/playlist?list=PLF4lVL1sPDSk62veBXXB0bXk0NmW4PHbu");

            ProcessUri(startUri);
        }

        static Uri ResolveRedirection(Uri startUri)
        {
            WebRequest request = WebRequest.Create(startUri);
            WebResponse response = request.GetResponse();
            return response.ResponseUri;
        }

        static void ProcessUri(Uri pageUri)
        {
            string hrefOriginal;
            if (!hrefDictionary.ContainsKey(pageUri.AbsoluteUri))
            {
                pageUri = ResolveRedirection(pageUri);
            }

            if(pagesDictionary.ContainsKey(pageUri.AbsoluteUri))
            {
                // if the page is already processed
                return;
            }

            // new page found, process


            WebClient wc = new WebClient();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(wc.OpenRead(pageUri));

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {

                HtmlAttribute att = link.Attributes["href"];
                string href = att.Value;
                string hrefAbsolute;

                if (!href.StartsWith("http"))
                {
                    hrefAbsolute = "http://" + pageUri.Host + href;
                }
                else
                {
                    hrefAbsolute = href;
                }
                pagesToProcess.Enqueue(new Uri(hrefAbsolute));
            }
        }
    }
}