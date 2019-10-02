using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace BookStoreDesk.ActionFilters
{
    public class ControllerFilterAdmin : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            UserViewModel user;
            if (context.HttpContext.Session.Keys.Contains("UserData") && context.HttpContext.Session.GetString("UserData").Length > 0)
            {
                user = JsonConvert.DeserializeObject<UserViewModel>(context.HttpContext.Session.GetString("UserData"));
                if (user.IsAdmin) return;
            }

            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }
    }
}
