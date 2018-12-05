using System.Collections.Generic;
using EAI.Template.API.Model;

namespace EAI.Template.Domain
{
    public interface IApplicationService
    {
        List<ApplicationsDTO> GetAll();
        UserWithToken Login(string userName, string Password);
        bool IsAuthorized(string userName, string Password);
    }
}