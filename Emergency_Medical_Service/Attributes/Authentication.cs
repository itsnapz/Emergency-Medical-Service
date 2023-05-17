using Emergency_Medical_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Emergency_Medical_Service.Attributes;

public class Authentication : Attribute
{
    private readonly EMSService _service = new EMSService();
    
    public async Task OnAuthorizationHandle(AuthorizationFilterContext context)
    {
        
    }
}