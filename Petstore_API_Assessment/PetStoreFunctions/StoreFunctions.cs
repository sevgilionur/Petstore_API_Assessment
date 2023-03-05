using Petstore_API_Assessment.Resources;
using System.Net;
using NUnit.Framework.Internal;
using RestSharp;
using Petstore_API_Assessment.Utils;

namespace Petstore_API_Assessment.PetStoreFunctions
{
    public class StoreFunctions
    {
        StoreRequests body = new StoreRequests { id = 123, petId = 6, quantity = 85, status = "placed", complete = true };
        int id;
      
        [SetUp]
        public void testStarted()
        {
            Console.WriteLine("Test started");
            id = body.id;
        }

        [Test, Order(1)]
        public void addStore()
        {

            RestClient client = new RestClient(BaseURL.storeURL);
            RestRequest request = new RestRequest("order");
            request.AddJsonBody(body);
            var response = client.Post(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(2)]
        public void findStoreById()
        {
            RestClient client = new RestClient(BaseURL.storeURL);
            RestRequest request = new RestRequest("order/" + id.ToString());
            var response = client.Get(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(3)]
        public void deleteStore()
        {

            RestClient client = new RestClient(BaseURL.storeURL);
            RestRequest request = new RestRequest("order/" + id.ToString());
            var response = client.Delete(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(4)]
        public void findInventory()
        {

            RestClient client = new RestClient(BaseURL.storeURL);
            RestRequest request = new RestRequest("inventory");
            var response = client.Get(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TearDown]
        public void endTest()
        {
            Console.WriteLine("Test completed");

        }
    }
}
