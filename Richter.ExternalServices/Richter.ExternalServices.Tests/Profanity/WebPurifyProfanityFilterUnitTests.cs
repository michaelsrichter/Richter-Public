using Moq;
using NUnit.Framework;
using Richter.ExternalServices.Profanity;
using Richter.ExternalServices.Profanity.Interfaces;
using Richter.ExternalServices.Profanity.WebPurify;

namespace Richter.ExternalServices.Tests.Profanity
{
    [TestFixture]
    public class WebPurifyProfanityFilterUnitTests
    {
        [Test]
        public void TestFilterContainsProfanity()
        {
            //Arrange
            var mockWebPurifyProfanityFilterService = new Mock<IProfanityFilterService>();
            var expectedCount = 3;
            var expectedExpletives = new[] {"banana", "apple", "chicken"};
            var xmlresponse = string.Format(
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <rsp stat=""ok"">
                              <method>webpurify.live.return</method>
                              <format>rest</format>
                              <found>{0}</found>
                              <expletive>{1}</expletive>
                              <expletive>{2}</expletive>
                              <expletive>{3}</expletive>
                              <api_key>api_key</api_key>
                            </rsp>",
                expectedCount, expectedExpletives[0], expectedExpletives[1], expectedExpletives[2]);
            var request = new ProfanityFilterRequest
            {
                Language = "en",
                Text = "We are just testing the XML Parsing here, so this is ignored"
            };
            mockWebPurifyProfanityFilterService
                .Setup(m => m.Check(request))
                .Returns(xmlresponse);

            //Act
            var profanityFilter = new WebPurifyProfanityFilter(mockWebPurifyProfanityFilterService.Object);
            var resultResponse =
                profanityFilter.ContainsProfanity(request);


            //Assert
            Assert.AreEqual(expectedCount, resultResponse.Count);
            Assert.AreEqual(expectedCount, resultResponse.Expletives.Length);
            Assert.AreEqual(expectedExpletives[0], resultResponse.Expletives[0]);
            Assert.AreEqual(expectedExpletives[1], resultResponse.Expletives[1]);
        }

        [Test]
        public void TestWebPurifySettings()
        {
            //Arrange
            WebPurifySettings baseSettings = new WebPurifySettings();

            //Assert
            Assert.AreEqual("Test Key", baseSettings.ApiKey);
        }

        [Test]
        public void TestWebPurifySettingsOverride()
        {
            //Arrange
            WebPurifySettings baseSettings = new MyWebPurifySettings();

            //Assert
            Assert.AreEqual("1234567", baseSettings.ApiKey);
        }
    }
}