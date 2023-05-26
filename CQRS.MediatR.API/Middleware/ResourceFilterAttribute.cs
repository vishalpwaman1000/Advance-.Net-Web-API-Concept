using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRS.MediatR.API.Middleware
{
    public class ResourceFilterAttribute : Attribute, IResourceFilter
    {

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            /*if(context.HttpContext.Request.Path.Value.ToLower().Contains("getoperation")) 
            {
                context.Result = new BadRequestObjectResult(
                    new
                    {
                        Version = new[] {"This Resource UnAvailable"}
                    });
            }*/
            Console.WriteLine("OnResourceExecuted method In Resurce Filter Calling");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OnResourceExecuted method In Resurce Filter Calling");
        }

        
    }
}
