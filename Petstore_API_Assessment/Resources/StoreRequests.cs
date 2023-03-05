namespace Petstore_API_Assessment.Resources
{
    public class StoreRequests
    {
        public int id { get; set; }
        public int petId { get; set; }
        public int quantity { get; set; }
        public string shipDate { get; set; }
        public string status { get; set; }
        public Boolean complete { get; set; }
    }
}
