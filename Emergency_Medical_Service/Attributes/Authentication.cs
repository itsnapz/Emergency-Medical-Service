using Emergency_Medical_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Emergency_Medical_Service.Attributes;

public class Authentication : ActionFilterAttribute
{
    private readonly EMSService _service = new EMSService();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpcontext = context.HttpContext;
        var doctorId = httpcontext.Request.Cookies["doctorId"];
        if (doctorId != null)
        {
            context.ActionArguments["doctorid"] = doctorId;
        }
        else
        {
            var controller = context.Controller as Controller;
            context.Result = controller.Redirect("/Home/Index");
        }
    }
}