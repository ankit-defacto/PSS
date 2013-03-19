
namespace PSS.WebWithAuth.Filters
{
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// JSON error handler attribute
    /// </summary>
    public class HandleJsonErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            filterContext.Result = new JsonResult 
            { 
                Data = new 
                {
                    message = filterContext.Exception == null ? "There was a problem with that request." : filterContext.Exception.Message
                }
            };

            filterContext.ExceptionHandled = true;
        }
    }
}