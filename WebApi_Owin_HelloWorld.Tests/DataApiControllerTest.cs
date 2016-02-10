using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Testing;
using System.Net.Http;
using System.Net.Http.Formatting;
using WebApi_Owin_HelloWorld.Controllers;
using System.Threading.Tasks;

namespace WebApi_Owin_HelloWorld.Tests
{
    [TestClass]
    public class DataApiControllerTest
    {
        [TestMethod]
        public async Task Strings_Should_Concatenate()
        {
            using (var server = TestServer.Create<MockStartup>()) //create a TestServer using MockStartup (Microsoft.Owin.Testing), which is completely in-memory and only for testing
            {
                //Assign
                var mergeRequest = new { StrA = "String A", StrB = "String B" };
                var response = await server.HttpClient.PostAsJsonAsync("api/DataApi/ContatenateStrings", mergeRequest); //PostAsJsonAsync is provided by System.Net.Http.Formatting

                //Act
                var mergeResponse = await response.Content.ReadAsAsync<MergeResponse>();

                //Assert
                Assert.IsTrue(response.IsSuccessStatusCode);
                Assert.AreEqual(mergeResponse.Concatenated, mergeRequest.StrA + " " + mergeRequest.StrB);
            }
        }
    }
}
