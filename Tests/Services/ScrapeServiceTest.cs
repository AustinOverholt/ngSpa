using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ngSpa.Services;
using System.Collections.Generic;
using ngSpa.Model.Domain;

namespace ngSpa.Tests.Services
{
    [TestClass]
    public class ScrapeServiceTest
    {
        [TestMethod]
        public void ScrapeServiceMain()
        {
            ScrapeService svc = new ScrapeService();
            var model = svc.Scrape(
                new Scrape()
                {
                    html = "https://www.wikipedia.org/",
                });
            Assert.IsNotNull(model);
        }
    }
}
