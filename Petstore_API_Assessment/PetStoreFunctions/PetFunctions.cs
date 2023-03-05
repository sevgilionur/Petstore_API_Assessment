using Petstore_API_Assessment.Resources;
using System.Net;
using NUnit.Framework.Internal;
using RestSharp;
using Petstore_API_Assessment.Utils;

namespace Petstore_API_Assessment.PetStoreFunctions
{
    public class PetTests
    {
        PetRequests body = new PetRequests { Id = 10, Name = "chiva", Status = "available" };
        int id;
        HttpStatusCode statusCode;
        int statusCodeNum;

        [SetUp]
        public void testStarted()
        {
            Console.WriteLine("Test started");
            id = body.Id;
        }


        [Test, Order(1)]
        public void addPet()
        {

            RestClient client = new RestClient(BaseURL.petURL);
            RestRequest request = new RestRequest();
            request.AddJsonBody(body);
            var response = client.Post(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            statusCodeNum = (int)statusCode;
            Assert.That(200, Is.EqualTo(statusCodeNum));

        }

        [Test, Order(2)]

        public void updatePet()
        {
            RestClient client = new RestClient(BaseURL.petURL);
            RestRequest request = new RestRequest();
            body.Name = "Golden Dog";
            request.AddJsonBody(body);
            var response = client.Put(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            statusCodeNum = (int)statusCode;
            Assert.That(200, Is.EqualTo(statusCodeNum));


        }
        [Test, Order(3)]
        public void findPetByStatus()
        {
            RestClient client = new RestClient(BaseURL.petURL);
            RestRequest request = new RestRequest("findByStatus?status=available");
            var response = client.Get(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            statusCodeNum = (int)statusCode;
            Assert.That(200, Is.EqualTo(statusCodeNum));

        }

        [Test, Order(4)]
        public void findPetById()
        {

            RestClient client = new RestClient(BaseURL.petURL);
            RestRequest request = new RestRequest(id.ToString(), Method.Get);
            var response = client.Get(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            statusCodeNum = (int)statusCode;
            Assert.That(200, Is.EqualTo(statusCodeNum));

        }
        [Test, Order(5)]
        public void deletePet()
        {
            RestClient client = new RestClient(BaseURL.petURL);
            RestRequest request = new RestRequest(id.ToString(), Method.Delete);
            var response = client.Delete(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            statusCode = response.StatusCode;
            statusCodeNum = (int)statusCode;
            Assert.That(200, Is.EqualTo(statusCodeNum));
        }

        [TearDown]
        public void endTest()
        {
            Console.WriteLine("Test completed.");

        }
    }
}
