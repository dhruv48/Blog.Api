using Blog.Common.Constant;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Blog.Api.Helpers
{
    public static class ClaimHelper
    {
        public static long GetUserId(this HttpContext httpContext)
        {
            return Convert.ToInt64(httpContext.User.Claims.Where(c => c.Type == BlogConstant.UserId).FirstOrDefault().Value);
        }
        //public static string GetUserName(this HttpContext httpContext)
        //{
        //    return (httpContext.User.Claims.Where(c => c.Type == BlogConstant.Name).FirstOrDefault().Value);
        //}
    }
}
