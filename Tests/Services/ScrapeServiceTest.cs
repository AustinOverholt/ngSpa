using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ngSpa.Services;
using System.Collections.Generic;

namespace ngSpa.Tests.Services
{
    [TestClass]
    public class ScrapeServiceTest
    {
        [TestMethod]
        public void ScrapeServiceMain()
        {
            ScrapeService svc = new ScrapeService();
            List<string> html = svc.ParseHtml("https://www.wikipedia.org/", "");
            Assert.IsNotNull(html);
        }
    }
}
