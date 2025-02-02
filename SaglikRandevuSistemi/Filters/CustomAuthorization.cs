using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SaglikRandevuSistemi.Filters
{
    public class CustomAuthorization : ActionFilterAttribute
    {
        private readonly string _requiredRole;

        public CustomAuthorization(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var role = context.HttpContext.Session.GetString("UserRole");
            if (role != _requiredRole)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            } 

            base.OnActionExecuted(context);
        }

    }
}
