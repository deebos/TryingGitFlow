using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EAI.Template.API.Middlewares;
using EAI.Template.API.Model;
using EAI.Template.Core.Exceptions;
using EAI.Template.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EAI.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Project")]
    [BasicAuthorize()]
    public class ApplicationsController : ControllerBase
    {
        private IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [ResponseCache(Duration =120)]
        public ActionResult<IEnumerable<ApplicationsDTO>> Get()
        {
           
            return _applicationService.GetAll();
        }

        [HttpGet("{id}")]
        public ApplicationsDTO GetById(int id)
        {
            throw new APIException("1001", "API Exception",HttpStatusCode.BadRequest);
            return _applicationService.GetAll().FirstOrDefault();
        }


       
    }
}