using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Services
{
    public class ScrapeService
    {
        // pass in link to be parsed and 
        public List<string> ParseHtml(string html, string keyword)
        {

            var document = new HtmlWeb().Load(html + keyword);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }
    }
}
