using Petstore_API_Assessment.Resources;
using System.Net;
using NUnit.Framework.Internal;
using RestSharp;
using Petstore_API_Assessment.Utils;

namespace Petstore_API_Assessment.PetStoreFunctions
{
    public class UserFunctions
    {
        UserRequests body = new UserRequests { id = 8795, username = "Onursevgili", firstName = "Onur", lastName = "Sevgili", email = "onur.sevgili@gmail.com", password = "1234", phone = "901208008", userStatus = 3 };
        int id;
        HttpStatusCode statusCode;
        int numericStatusCode;

        [SetUp]
        public void testStarted()
        {
            Console.WriteLine("Test started");
            id = body.id;
        }


        [Test, Order(1)]
        public void addUser()
        {

            RestClient client = new RestClient(BaseURL.userURL);
            RestRequest request = new RestRequest();
            request.AddJsonBody(body);
            var response = client.Post(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            numericStatusCode = (int)statusCode;
            Assert.That(200, Is.EqualTo(numericStatusCode));

        }

        [Test, Order(2)]
        public void findUserByName()
        {
            RestClient client = new RestClient(BaseURL.userURL);
            RestRequest request = new RestRequest(body.username);
            var response = client.Get(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            Console.WriteLine(response.Content);
            statusCode = response.StatusCode;
            numericStatusCode = (int)statusCode;
            Assert.That(200, Is.EqualTo(numericStatusCode));

        }
        [Test, Order(3)]
        public void updateUser()
        {
            body.username = "onur.sevgili";
            RestClient client = new RestClient(BaseURL.userURL);
            RestRequest request = new RestRequest(body.username);
            request.AddJsonBody(body);
            var response = client.Put(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            numericStatusCode = (int)statusCode;
            Assert.That(200, Is.EqualTo(numericStatusCode));

        }

        [Test, Order(4)]
        public void deleteUser()
        {

            RestClient client = new RestClient(BaseURL.userURL);
            RestRequest request = new RestRequest(body.username);
            var response = client.Delete(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            numericStatusCode = (int)statusCode;
            Assert.That(200, Is.EqualTo(numericStatusCode));
        }

        [TearDown]
        public void endTest()
        {
            Console.WriteLine("Test completed");
        }

    }
}
