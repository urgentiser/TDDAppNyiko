using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.UnitTest.Fixtures;
using TDDApi.Controllers;
using TDDApi.Models;
using TDDApi.Services;

namespace TDD.UnitTest.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccessReturnStatusCode200()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                 .Setup(Service => Service.GetAllUsers())
                  .ReturnsAsync(UserFixtures.GetTestUsers());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = (OkObjectResult) await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_OnSuccess_InvokesUserServiceExactelyOnce()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(Service => Service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockUserService.Verify(
                service => service.GetAllUsers(), 
                Times.Once());

        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(Service => Service.GetAllUsers())
                .ReturnsAsync(UserFixtures.GetTestUsers());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }
        [Fact]
        public async Task OnNoUserFound_Return404()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(Service => Service.GetAllUsers())
                .ReturnsAsync(new List<User>());
            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
            
        }
    }
}