using FluentAssertions;
using Moq;
using Moq.Protected;
using TDD.UnitTest.Fixtures;
using TDD.UnitTest.Helpers;
using TDDApi.Models;
using TDDApi.Services;

namespace TDD.UnitTest.Systems.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UserFixtures.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourcelist(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act 

            await sut.GetAllUsers();

            //Assert
            handlerMock
                .Protected()
                .Verify("SendAsync", 
                Times.Exactly(1), 
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
                );

        }
        [Fact]
        public async Task GetallUsers_WhenCalled_ReturnsListOfUsers()
        {
            //Arrange
            var expectedResponse = UserFixtures.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourcelist(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act 

          var result  =  await sut.GetAllUsers();

            //Assert
           result.Should().BeOfType<List<User>>();
        }

        [Fact]
        public static async Task GetallUsers_WhenHits404_ReturnsEmtyListOfUsers()
        {
            //Arrange
           
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act 

            var result = await sut.GetAllUsers();

            //Assert
            result.Count.Should().Be(0);
        }
    }
}
 