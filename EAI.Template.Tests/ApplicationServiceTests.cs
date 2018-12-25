using AutoMapper;
using EAI.Template.API.Model;
using EAI.Template.Core.Auth;
using EAI.Template.Data;
using EAI.Template.Data.Repository;
using EAI.Template.Domain;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace EAI.Template.Tests
{
    public class ApplicationServiceTests
    {
        private readonly Mock<IDistributedCache> _distributedCacheMoq;
        private readonly Mock<IMapper> _mapperMoq;
        private readonly IApplicationService _sut;
        private readonly Mock<ITokenBuilder> _tokenBuilderMoq;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public ApplicationServiceTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapperMoq = new Mock<IMapper>();
            _tokenBuilderMoq = new Mock<ITokenBuilder>();
            _distributedCacheMoq = new Mock<IDistributedCache>();

            _sut = new ApplicationService(_unitOfWork.Object, _mapperMoq.Object,
                _tokenBuilderMoq.Object, _distributedCacheMoq.Object);
        }

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
        public void GetAll_Release2_BugFix()
        {
        }

        [Fact]
        public void GetAll_ReleaseBranch_ShouldMergeToMaster()
        {
            //taken from latest develop
        }

        [Fact]
        public void GetAll_TestFromBranchTwo_ShouldResultToMergeConflict()
        {
            //:D
        }

        [Fact]
        public void Login_UsernameOrPasswordAreIncorrect_ShouldThrowUnauthorizedAccessException()
        {
            //Arrange
            var password = "wrongPassword";
            var username = "wrongUsername";
            var appRepo = new Mock<IRepository<Applications>>();
            appRepo.Setup(ar => ar.FirstOrDefault(It.IsAny<Expression<Func<Applications, bool>>>(),
                It.IsAny<Expression<Func<Applications, object>>>())).Returns(() => null);
            _unitOfWork.Setup(u => u.GetRepository<Applications>()).Returns(appRepo.Object);

            //Act

            //Assert
            Assert.Throws<UnauthorizedAccessException>(() => _sut.Login(username, password));

        }
        [Fact]
        public void Login_UsernameAndPasswordAreCorrect_ShouldCallBuildFromTokenBuilder()
        {
            var password = "";
            string username = "Totti";
            int c = 0;
            
            var appRepoMock = new Mock<IRepository<Applications>>();

            appRepoMock.Setup(ar => ar.FirstOrDefault(It.IsAny<Expression<Func<Applications, bool>>>(),It.IsAny<Expression<Func<Applications,object>>>()))
                .Returns(new Applications() { Id = 1 });

            _unitOfWork.Setup(u => u.GetRepository<Applications>())
                .Returns(appRepoMock.Object);
            
            _sut.Login(username, password);
            
            Assert.Equal(1,c);
           

            Assert.Throws<ArgumentException>(() => _sut.Login(username, password));
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