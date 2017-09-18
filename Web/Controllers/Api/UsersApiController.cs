using ngSpa.Model;
using ngSpa.Model.Responses;
using ngSpa.Services;
using ngSpa.Services.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ngSpa.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        private IUserService _userService;
        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                ItemsResponse<Users> resp = new ItemsResponse<Users>();
                resp.Items = _userService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.BadRequest, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}