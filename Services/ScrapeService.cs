using HtmlAgilityPack;
using ngSpa.Model.Domain;
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
        // pass in link to be parsed
        public List<string> Scrape(Scrape model)
        {

            var document = new HtmlWeb().Load(model.html);
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
