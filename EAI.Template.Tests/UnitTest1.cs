using System;
using System.Collections.Generic;
using AutoMapper;
using EAI.Template.API.Model;
using EAI.Template.Core.Auth;
using EAI.Template.Data.Repository;
using EAI.Template.Domain;
using Microsoft.Extensions.Caching.Distributed;
using Xunit;

namespace EAI.Template.Tests
{
    public class UnitTest1
    {
        private readonly IApplicationService _applicationService;

        public UnitTest1() 
        {
           
        }
        //[Fact]
        //public void Test1()
        //{
        //    _applicationService.GetAll();

        //    Assert.Throws(new NotImplementedException());
        //}

        [Fact]
        public void GetAll_WhenUsernameIsNull_ShouldThrowArgumentNullException()
        {
            List<ApplicationsDTO> applications;
             
            applications = _applicationService.GetAll();

            Assert.Equal(4, applications.Count);
            Assert.Throws<ArgumentException>("ParamName",() => _applicationService.GetAll());
            Assert.Throws<NotImplementedException>( () => _applicationService.GetAll());
            var ex = Assert.Throws<ArgumentNullException>(() => _applicationService.Login("", ""));
            Assert.Equal("Name", ex.ParamName);

            //Assert.Raises<EventArgs>();
            //Assert.PropertyChanged(_applicationService, "nameProperty", () => _applicationService.GetAll());

        }

        [Fact]
        public void GetAll_ReleaseBranch_ShouldMergeToMaster()
        {
            //taken from latest develop
        }
    }
}
