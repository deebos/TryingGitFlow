using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAI.Template.API.Middlewares;
using EAI.Template.API.Model;
using EAI.Template.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAI.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IApplicationService _applicationService;
        public AccountController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]       
        public ActionResult<UserWithToken> Login([FromBody] LoginModel loginModel)
        {
            return _applicationService.Login(loginModel.UserName, loginModel.Password);
        }
    }
}