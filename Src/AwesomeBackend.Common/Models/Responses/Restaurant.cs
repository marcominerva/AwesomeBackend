using System;

namespace AwesomeBackend.Common.Models.Responses
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public int RatingsCount { get; set; }

        public double RatingScore { get; set; }
    }
}
