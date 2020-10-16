using System.Collections.Generic;
using System.Linq;
using DomainApi.Models;
using DomainApi.Services;
using NUnit.Framework;

namespace DomainApi.Tests.Services
{
    [TestFixture]
    public class SubDomainServiceTests
    {
        [Test]
        public void Enumerate_should_return_valid_result()
        {
            // Arrange
            var mockInput = "testdomain.com";
            var expectedCount = 702;
            var service = new SubDomainService();

            // Act
            var result = service.Enumerate(mockInput);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<string>), result.GetType());
            Assert.AreEqual(expectedCount, result.Count);
        }

        [Test]
        public void FindIpAddresses_should_return_valid_result()
        {
            // Arrange
            var mockInput = new List<string> { "www.yahoo.com", "www.google.com" };
            var expectedCount = mockInput.Count;
            var service = new SubDomainService();

            // Act
            var result = service.FindIpAddresses(mockInput);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<SubDomain>), result.GetType());
            Assert.AreEqual(expectedCount, result.Count);
        }

        [Test]
        public void FindIpAddresses_should_return_unknown_host_for_invalid_input()
        {
            // Arrange
            var mockInput = new List<string> { "invalid input" };
            var expectedCount = mockInput.Count;
            var expectedOutput = "No such host is known";
            var service = new SubDomainService();

            // Act
            var result = service.FindIpAddresses(mockInput);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<SubDomain>), result.GetType());
            Assert.AreEqual(expectedCount, result.Count);
            Assert.AreEqual(expectedOutput, result.First().IpAddresses.First());
        }
    }
}