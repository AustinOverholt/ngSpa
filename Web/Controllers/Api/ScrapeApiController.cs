using ngSpa.Model.Domain;
using ngSpa.Model.Requests;
using ngSpa.Model.Responses;
using ngSpa.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace ngSpa.Web.Controllers.Api
{
    [RoutePrefix("api/scrape")]
    public class ScrapeApiController : ApiController
    {
        ScrapeService scrapeService = new ScrapeService();

        [Route(), HttpPost]
        public HttpResponseMessage Insert(Scrape model)
        {
            try
            {
                ItemsResponse<string> resp = new ItemsResponse<string>();
                resp.Items = scrapeService.Scrape(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);

            }
            catch (Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("insert"), HttpPost]
        public HttpResponseMessage InsertData(ScrapeAddRequest model)
        {
            try
            {
                ItemResponse<int> resp = new ItemResponse<int>();
                resp.Item = scrapeService.ScrapeInsert(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route(), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<ScrapeDb> resp = new ItemsResponse<ScrapeDb>();
                resp.Items = scrapeService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            } 
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

    }
}