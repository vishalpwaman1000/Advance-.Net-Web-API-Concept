using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRS.MediatR.API.Middleware
{
    public class ActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _callerName;
        public ActionFilterAttribute(string callerName)
        {
            _callerName = callerName;   
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"\n{_callerName} - This Filter Executed On OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"\n{_callerName} - This Filter Executed On OnActionExecuting");
        }
    }
}
