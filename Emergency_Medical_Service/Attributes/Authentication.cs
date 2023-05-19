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
        var controller = context.Controller as Controller;
        if (doctorId != null)
        {
            context.Result = controller.Redirect("/Home/Responds");
        }
        else
        {
            context.Result = controller.Redirect("/Home/Index");
        }
    }
}