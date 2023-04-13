using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day05.Models.ExceptionHandler
{
    public class NoOrdersException: HandleErrorAttribute
    {
        public NoOrdersException() { }


        public override void OnException(ExceptionContext filterContext)
        {

            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            filterContext.Result = new ViewResult
            {
                ViewName = "OrderError",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            };
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
        }
    }
