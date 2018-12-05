using EAI.Template.API.Model;
using EAI.Template.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EAI.Template.Core.Auth;
using Microsoft.EntityFrameworkCore;
using EAI.Template.Data.Repository;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using EAI.Template.Core.Cache;
namespace EAI.Template.Domain
{
    public class ApplicationService : IApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ITokenBuilder _tokenBuilder;
        private readonly IDistributedCache distributedCache;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper, ITokenBuilder tokenBuilder, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenBuilder = tokenBuilder;
            this.distributedCache = distributedCache;
           
        }


        public List<ApplicationsDTO> GetAll()
        {
            throw new NotImplementedException();
            string key = "GetAllApplications";          

            var applications = distributedCache.RetrieveFromCache <List<Applications>>(key);

            if (applications==null)
            {
                applications = _unitOfWork.GetRepository<Applications>().GetAll().ToList();

                distributedCache.SaveToCache(key, applications,10);

            }

            return _mapper.Map<List<Applications>, List<ApplicationsDTO>>(applications);
        }

        public UserWithToken Login(string userName, string Password)
        {
            var user = _unitOfWork.GetRepository<Applications>().FirstOrDefault(x => x.UserName == userName, x => x.Scopes);


            if (user == null)
            {
                throw new UnauthorizedAccessException("username/password aren't right");
            }


            var expiresIn = DateTime.Now + TokenAuthOption.ExpiresSpan;
            var token = _tokenBuilder.Build(user.Name, user.Scopes.Select(x => x.ScopeName).ToArray(), expiresIn);

            return new UserWithToken
            {
                ExpiresAt = expiresIn,
                Token = token
            };
        }

        public bool IsAuthorized(string userName, string Password)
        {
            var user = _unitOfWork.GetRepository<Applications>().FirstOrDefault(x => x.UserName == userName);


            if (user == null)
            {
                throw new UnauthorizedAccessException("username/password aren't right");
            }

            return true;
        }


    }
}
