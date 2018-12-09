using EAI.Template.API.Model;
using EAI.Template.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace EAI.Template.Tests
{
    public class UnitTest1
    {
        private readonly IApplicationService _sut;

        public UnitTest1()
        {
        }
        //commit from feature 1
        //[Fact]
        //public void Test1()
        //{
        //    _applicationService.GetAll();

        //    Assert.Throws(new NotImplementedException());
        //}

        [Fact]
        public void GetAll_NormalCase_ShouldReturnListOfApplicationDto()
        {
            List<ApplicationsDTO> applications;

            applications = _sut.GetAll();
            Assert.IsType<List<ApplicationsDTO>>(applications);

            Assert.Equal(4, applications.Count);
            Assert.Throws<ArgumentException>("ParamName", () => _sut.GetAll());
            Assert.Throws<NotImplementedException>(() => _sut.GetAll());
            var ex = Assert.Throws<ArgumentNullException>(() => _sut.Login("", ""));
            Assert.Equal("Name", ex.ParamName);

            //Assert.Raises<EventArgs>();
            //Assert.PropertyChanged(_applicationService, "nameProperty", () => _applicationService.GetAll());
        }

        [Fact]
        public void Login_WhenUsernameIsNull_ShouldThrowArgumentNullException()
        {
            var password = "P@ssw0rd";
            string username = null;

            var ex = Assert.Throws<ArgumentNullException>(() => _sut.Login(username, password));
            Assert.Equal("userName", ex.ParamName);
        }

        [Fact]
        public void GetAll_TestFromBranchTwo_ShouldResultToMergeConflict()
        {
            //:D
        }

        [Fact]
        public void GetAll_ReleaseBranch_ShouldMergeToMaster()
        {
            //taken from latest develop
        }
        [Fact]
        public void GetAll_Release2_BugFix()
        {
            
        }

        [Fact]
        public void ThirdUser_AddingFeature_ToRepo()
        {
            //third user code
        }
        [Fact]
        public void ThirdUser_HotFix_ToRepo()
        {
            //third user Hot fix
        }
    }
}