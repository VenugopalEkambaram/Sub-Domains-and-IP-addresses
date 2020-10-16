using DomainApi.Controllers;
using DomainApi.Models;
using DomainApi.Services;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace DomainApi.Tests.Controllers
{
    [TestFixture]
    public class SubDomainControllerTests
    {
        [Test]
        public void Get_should_return_valid_result()
        {
            // Arrange
            var mockSubDomainService = Substitute.For<ISubDomainService>();
            var mockInput = "testdomain.com";
            mockSubDomainService.Enumerate(Arg.Any<string>()).Returns(new List<string>());
            var controller = new SubDomainController(mockSubDomainService);

            // Act
            var result = (OkNegotiatedContentResult<List<string>>)controller.Get(mockInput);

            // Assert
            mockSubDomainService.Received(1).Enumerate(mockInput);
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<string>), result.Content.GetType());
            Assert.AreEqual(0, result.Content.Count());
        }

        [Test]
        public void FindIpAddress_should_return_valid_result()
        {
            // Arrange
            var mockInput = new List<string>();
            var expectedOutput = new List<SubDomain>();
            var mockSubDomainService = Substitute.For<ISubDomainService>();
            mockSubDomainService.FindIpAddresses(Arg.Any<List<string>>()).Returns(expectedOutput);
            var controller = new SubDomainController(mockSubDomainService);

            // Act
            var result = (OkNegotiatedContentResult<List<SubDomain>>)controller.FindIpAddress(mockInput);

            // Assert
            mockSubDomainService.Received(1).FindIpAddresses(mockInput);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Content.Count);
        }
    }
}