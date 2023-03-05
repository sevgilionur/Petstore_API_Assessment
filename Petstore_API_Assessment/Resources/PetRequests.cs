﻿namespace Petstore_API_Assessment.Resources
{
    public class PetRequests
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }


        public List<string> PhotoUrls { get; set; }


        public List<Category> Tags { get; set; }


        public string Status { get; set; }
    }

    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
