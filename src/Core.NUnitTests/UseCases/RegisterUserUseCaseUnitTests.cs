using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.UseCases;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Core.NUnitTests.UseCases
{
    [TestFixture]
    public class RegisterUserUseCaseUnitTests
    {        
        public RegisterUserUseCaseUnitTests()
        {
            
        }

        [Test]
        public async Task Can_Register_User()
        {

            // arrange

            // 1. We need to store the user data somehow
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
              .Returns(Task.FromResult(new CreateUserResponse("", true)));

            // 2. The use case and star of this test
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);


            // 3. The output port is the mechanism to pass response data from the use case to a Presenter 
            // for final preparation to deliver back to the UI/web page/api response etc.
            var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterUserResponse>()));

            // act

            // 4. We need a request model to carry data into the use case from the upper layer (UI, Controller etc.)
            var response = await useCase.Handle(new RegisterUserRequest("firstName", "lastName", "me@domain.com", "userName", "password"), mockOutputPort.Object);

            // assert
            Assert.True(response);

        }
    }
}
