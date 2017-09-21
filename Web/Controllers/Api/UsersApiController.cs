using ngSpa.Model;
using ngSpa.Model.Domain;
using ngSpa.Model.Requests;
using ngSpa.Model.Responses;
using ngSpa.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ngSpa.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        UserService userService = new UserService();

        [Route(), HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                ItemsResponse<Users> resp = new ItemsResponse<Users>();
                resp.Items = userService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage SelectById(int id)
        {
            try
            {
                ItemResponse<Users> resp = new ItemResponse<Users>();
                resp.Item = userService.SelectById(id);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(UserAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                ItemResponse<int> resp = new ItemResponse<int>();
                resp.Item = userService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route(), HttpPut]
        public HttpResponseMessage Update(UserUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                SuccessResponse resp = new SuccessResponse();
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    model.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    model.ModifiedBy = "Anonymous";
                }
                userService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            SuccessResponse resp = new SuccessResponse();
            userService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [Route("grid"), HttpPost]
        public HttpResponseMessage GetGrid(GridRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                ItemResponse<UsersGrid> resp = new ItemResponse<UsersGrid>();
                resp.Item = userService.GetGrid(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}