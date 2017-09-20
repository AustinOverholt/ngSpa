﻿using ngSpa.Model;
using ngSpa.Model.Requests;
using ngSpa.Model.Responses;
using ngSpa.Services;
using System;
using System.Net;
using System.Net.Http;
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
    }
}