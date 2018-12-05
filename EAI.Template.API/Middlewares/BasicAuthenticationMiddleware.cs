using EAI.Template.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EAI.Template.API.Middlewares
{
    public class BasicAuthorizeFilter : IAuthorizationFilter
    {
        private IApplicationService applicationService;
        public BasicAuthorizeFilter(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
               
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
               
                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];
               
                if (IsAuthorized(username, password))
                {
                    return;
                }
            }
          
            context.Result = new UnauthorizedResult();
        }
       
        public bool IsAuthorized(string username, string password)
        {
            return applicationService.IsAuthorized(username, password);
        }
    }
}
